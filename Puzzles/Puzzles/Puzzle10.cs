using System.Diagnostics.Tracing;
using System.Text;

namespace AoC2022.Puzzles;

public class Puzzle10 : PuzzleBase<string[], int, string>
{
    protected override string Filename => "Input/puzzle-input-10";
    protected override string PuzzleTitle => "--- Day 10: Cathode-Ray Tube ---";

    public override int PartOne(string[] input)
    {
        var cpu = new CPU();

        foreach (var line in input)
        {
            var s = line.Split(' ');
            if (s[0] == "noop")
            {
                cpu.Execute(CPU.Instruction.NOOP);
            }
            else
            {
                cpu.Execute(CPU.Instruction.ADDX, int.Parse(s[1]));
            }
            
            if (cpu.GetTicks() >= 220)
            {
                break;
            }
        }

        return cpu.SignalStrength();
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
        return input.GetAllLines().ToArray();
    }    
    
    private class CPU
    {
        public int Register { get; set; }
        private int _circuitClock;
        private int _signalStrength;

        public CPU()
        {
            _circuitClock = 0;
            _signalStrength = 0;
            Register = 1;
        }


        public void Execute(Instruction instruction, int parameter = 0)
        {
            switch (instruction)
            {
                case Instruction.NOOP: Noop();
                    break;
                case Instruction.ADDX: Addx(parameter);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null);
            }
        }

        private void Noop()
        {
            AddTick();
        }
        
        public void Addx(int x)
        {
            AddTick();
            AddTick();
            Register += x;
        }

        private void AddTick(int part = 1)
        {
            _circuitClock++;
            if (part == 1)
            {
                if (_circuitClock % 40 == 20)
                {
                    _signalStrength += Register * _circuitClock;
                }
            }
            
        }
        
        public enum Instruction
        {
            NOOP, ADDX
        }

        public int SignalStrength()
        {
            return _signalStrength;
        }

        public int GetTicks()
        {
            return _circuitClock;
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