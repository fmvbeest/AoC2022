using System.Data;
using System.Runtime.CompilerServices;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle15 : PuzzleBase<IEnumerable<string>, int, int>
{
    protected override string Filename => "Input/puzzle-input-15";
    protected override string PuzzleTitle => "--- Day 15: Beacon Exclusion Zone ---";

    public override int PartOne(IEnumerable<string> input)
    {
        var lines = input.ToList();

        var sensors = new List<Sensor>();
        var knownBeacons = new HashSet<Coordinate>();
        
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
            knownBeacons.Add(beacon);
            var sensor = new Sensor(new Coordinate(sensorx, sensory), beacon);
            sensors.Add(sensor);
        }

        var blockers = new HashSet<Coordinate>();

        foreach (var sensor in sensors)
        {
            var blocks = sensor.GetInRange(2000000)
                .Where(c => c.ManhattanDistance(sensor) <= sensor.Range());

            foreach (var block in blocks)
            {
                if (!knownBeacons.Contains(block))
                {
                    blockers.Add(block);
                }
            }
        }

        return blockers.Count;
    }

    public override int PartTwo(IEnumerable<string> input)
    {
        var lines = input.ToList();

        var sensors = new List<Sensor>();
        var knownBeacons = new HashSet<Coordinate>();
        
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
            knownBeacons.Add(beacon);
            var sensor = new Sensor(new Coordinate(sensorx, sensory), beacon);
            sensors.Add(sensor);
        }

        var blockers = new HashSet<Coordinate>();

        foreach (var sensor in sensors)
        {
            var blocks = sensor.GetInRange(2000000)
                .Where(c => c.ManhattanDistance(sensor) <= sensor.Range());

            foreach (var block in blocks)
            {
                if (!knownBeacons.Contains(block))
                {
                    blockers.Add(block);
                }
            }
        }

        return blockers.Count;
    }
    
    public override IEnumerable<string> Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetAllLines();
    }

    private class Sensor : Coordinate
    {
        private Coordinate _closestBeacon;

        private int _range;

        public Sensor(int x, int y, Coordinate beacon) : base(x, y)
        {
            _closestBeacon = beacon;
            var diff = (x, y) - beacon;
            _range = Math.Abs(diff.X) + Math.Abs(diff.Y);
        }
        
        public Sensor(Coordinate sensor, Coordinate beacon) : base(sensor)
        {
            _closestBeacon = beacon;
            var diff = sensor - beacon;
            _range = Math.Abs(diff.X) + Math.Abs(diff.Y);
        }

        public IEnumerable<Coordinate> GetInRange(int y)
        {
            var candidates = new List<Coordinate>();
            if (y > Y + _range && y < Y - _range)
            {
                return candidates;
            }
            var min = new Coordinate(this.X - _range, y);
            candidates.Add(min);
            return HorizontalRange(min, 1, (this.X + _range) - min.X, candidates);
        }

        public int Range()
        {
            return _range;
        }
            
    }
}