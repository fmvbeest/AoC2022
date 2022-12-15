using System.Data;
using System.Runtime.CompilerServices;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle15 : PuzzleBase<(IEnumerable<Sensor> sensors, HashSet<string> beacons), int, int>
{
    protected override string Filename => "Input/puzzle-input-15";
    protected override string PuzzleTitle => "--- Day 15: Beacon Exclusion Zone ---";

    public override int PartOne((IEnumerable<Sensor> sensors, HashSet<string> beacons) input)
    {
        var (sensors, knownBeacons) = input;

        var y = 2000000;
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

    public override int PartTwo((IEnumerable<Sensor> sensors, HashSet<string> beacons) input)
    {
        var (sensors, knownBeacons) = input;

        var blockers = new HashSet<string>();

        foreach (var sensor in sensors)
        {
            var blocks = sensor.GetInRange(2000000)
                .Where(c => c.ManhattanDistance(sensor) <= sensor.Range());

            foreach (var block in blocks)
            {
                if (!knownBeacons.Contains(block.ToString()))
                {
                    blockers.Add(block.ToString());
                }
            }
        }

        return blockers.Count;
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

    private (int a, int b) Merge((int a, int b) rangeA, (int a, int b) rangeB)
    {
        

        return (Math.Min(rangeA.a, rangeB.a) ,Math.Max(rangeA.b, rangeB.b));
    }


    private bool Overlap((int a, int b) rangeA, (int a, int b) rangeB)
    {
        return rangeA.a <= rangeB.b && rangeB.a <= rangeA.b;
    }
    
    private bool Subrange((int a, int b) rangeA, (int a, int b) rangeB)
    {
        return rangeA.a >= rangeB.a && rangeA.b <= rangeB.b;
    }
}