using System.Diagnostics.Tracing;
using System.Text;

namespace AoC2022.Puzzles;

public class Puzzle10 : PuzzleBase<string[], int, string>
{
    protected override string Filename => "Input/puzzle-input-10";
    protected override string PuzzleTitle => "--- Day 10: Cathode-Ray Tube ---";

    public override int PartOne(string[] input)
    {
        var signalStrength = 0;
        var cycle = 0;
        var cpu = new CPU() { Register = 1 };

        foreach (var line in input)
        {
            cycle++;
            if (cycle % 40 == 20)
            {
                signalStrength += (cpu.Register * cycle);
            }
            
            var s = line.Split(' ');
            if (s[0] == "noop")
            {
                continue;
            }

            cycle++;
            if (cycle % 40 == 20)
            {
                signalStrength += (cpu.Register * cycle);
            }
            cpu.Addx(int.Parse(s[1]));

            if (cycle >= 220)
            {
                break;
            }
        }

        return signalStrength;
    }

    public override string PartTwo(string[] input)
    {
        var cycle = 0;
        var cpu = new CPU() { Register = 1 };
        var crt = new CRT(cpu.Register);

        foreach (var line in input)
        {
            cycle++;
            crt.DrawPixel(cycle, cpu.Register);
            
            var s = line.Split(' ');
            if (s[0] == "noop")
            {
                continue;
            }

            cycle++;
            crt.DrawPixel(cycle, cpu.Register);
            cpu.Addx(int.Parse(s[1]));

            if (cycle >= 240)
            {
                break;
            }
        }
        
        Console.WriteLine();
        var image = crt.Render();
        return image;
    }
    
    public override string[] Preprocess(IPuzzleInput input, int part = 1)
    {
        return input.GetInput().ToArray();
    }    
    
    private class CPU
    {
        public int Register { get; set; }
        
        public void Addx(int x)
        {
            Register += x;
        }
    }

    private class CRT
    {
        private (int x, int y, int z) _sprite;

        private readonly char[][] _screen;
        
        public CRT(int pos)
        {
            _sprite = (pos - 1, pos, pos + 1);
            _screen = new char[6][];
            for (var i = 0; i < _screen.Length; i++)
            {
                _screen[i] = new char[40];
            }
        }

        public void DrawPixel(int cycle, int sprite)
        {
            SetSprite(sprite);
            var row = (cycle - 1) / 40;
            var pos = (cycle - 1) % 40;
            _screen[row][pos] = GetPixel(pos);
        }

        private void SetSprite(int pos)
        {
            _sprite = (pos - 1, pos, pos + 1);
        }

        private char GetPixel(int pos)
        {
            return pos == _sprite.x || pos == _sprite.y || pos == _sprite.z ? '#' : '.';
        }

        public string Render()
        {
            return _screen.Aggregate(string.Empty, (current, screenRow) => current + (string.Join("", screenRow) + '\n'));
        }
    }
}