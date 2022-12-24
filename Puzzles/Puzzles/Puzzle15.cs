using System.Data;
using System.Runtime.CompilerServices;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle15 : PuzzleBase<(IEnumerable<Sensor> sensors, HashSet<string> beacons), int, long>
{
    protected override string Filename => "Input/puzzle-input-15";
    protected override string PuzzleTitle => "--- Day 15: Beacon Exclusion Zone ---";

    public override int PartOne((IEnumerable<Sensor> sensors, HashSet<string> beacons) input)
    {
        var (sensors, knownBeacons) = input;

        //const int y = 10;
        const int y = 2_000_000;
        var ranges = new List<(int a, int b)>();
        foreach (var sensor in sensors)
        {
            if (sensor.HorizontalBlockRange(y, out var range))
            {
                ranges.Add(range);
            }
        }
        ranges = ranges.OrderBy(x => x.a).ThenBy(x => x.b).ToList();
        var currentRange = ranges.First();
        var newRanges = new List<(int a, int b)>();

        foreach (var range in ranges.Skip(1))
        {
            if (Overlap(currentRange, range))
            {
                var newRange = Merge(currentRange, range);
                currentRange = newRange;
            }
            else
            {
                newRanges.Add(currentRange);
                currentRange = range;
            }
                 
        }
        newRanges.Add(currentRange);
        return newRanges.Sum(x => x.b - x.a);
    }

    public override long PartTwo((IEnumerable<Sensor> sensors, HashSet<string> beacons) input)
    {
        var (sensors, knownBeacons) = input;

        //const int limit = 20;
        const int limit = 4_000_000;
        const int multiplier = 4_000_000;
        var allRanges = new List<List<(int, int)>>();

        var xBeacon = 0;
        var yBeacon = 0;
        
        
        for (var i = 0; i < limit; i++)
        {
            var ranges = new List<(int a, int b)>();
            foreach (var sensor in sensors)
            {
                if (sensor.HorizontalBlockRange(i, out var range, useLimit:true, upper:limit))
                {
                    ranges.Add(range);
                }
            }
            ranges = ranges.OrderBy(x => x.a).ThenBy(x => x.b).ToList();

            var currentRange = ranges.First();
            var newRanges = new List<(int a, int b)>();

            foreach (var range in ranges.Skip(1))
            {
                if (Overlap(currentRange, range) || Adjacent(currentRange, range))
                {
                    var newRange = Merge(currentRange, range);
                    currentRange = newRange;
                }
                else
                {
                    newRanges.Add(currentRange);
                    currentRange = range;
                }
            }
            newRanges.Add(currentRange);

            if (newRanges.Sum(x => x.b - x.a) < limit)
            {
                yBeacon = i;
                xBeacon = newRanges.First().b + 1;
                break;
            }
            allRanges.Add(newRanges);
        }

        return (long)multiplier * xBeacon + yBeacon;
    }
    
    public override (IEnumerable<Sensor> sensors, HashSet<string> beacons) Preprocess(IPuzzleInput input, int part = 1)
    {
        var lines = input.GetAllLines();

        var sensors = new List<Sensor>();
        var knownBeacons = new HashSet<string>();
        
        foreach (var line in lines)
        {
            var s = line.Split(':');
            var sensorinfo = s[0].Split("at ")[^1];
            var beaconinfo = s[1].Split("at ")[^1];
            var sensorx = int.Parse(sensorinfo.Split(',')[0].Split('=')[^1]);
            var sensory = int.Parse(sensorinfo.Split(',')[1].Split('=')[^1]);
            var beaconx = int.Parse(beaconinfo.Split(',')[0].Split('=')[^1]);
            var beacony = int.Parse(beaconinfo.Split(',')[1].Split('=')[^1]);

            var beacon = new Coordinate(beaconx, beacony);
            knownBeacons.Add(beacon.ToString());
            var sensor = new Sensor(new Coordinate(sensorx, sensory), beacon);
            sensors.Add(sensor);
        }

        return (sensors, knownBeacons);
    }

    private static (int a, int b) Merge((int a, int b) rangeA, (int a, int b) rangeB)
    {
        return (Math.Min(rangeA.a, rangeB.a) ,Math.Max(rangeA.b, rangeB.b));
    }

    private static bool Overlap((int a, int b) rangeA, (int a, int b) rangeB)
    {
        return rangeA.a <= rangeB.b && rangeB.a <= rangeA.b;
    }

    private static bool Adjacent((int a, int b) rangeA, (int a, int b) rangeB)
    {
        return rangeA.b == rangeB.a - 1;
    }
}