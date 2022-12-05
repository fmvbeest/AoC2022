using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle5 : PuzzleBase<string, (Stack<char>[] SupplyCrates, Stack<Instruction> Instructions)>
{
    protected override string Filename => "Input/puzzle-input-05";
    protected override string PuzzleTitle => "--- Day 5: Supply Stacks ---";
    
    public Puzzle5() : base() { }
    public Puzzle5(IPuzzleInput input) : base(input) { }
    
    public override string PartOne()
    {
        var (supplyCrates, instructions) = PreparedInput;

        var crateMover = new CrateMover9000(PreparedInput.SupplyCrates);
        
        foreach (var instruction in PreparedInput.Instructions)
        {
            crateMover.ReadInstruction(instruction);
        }

        return PreparedInput.SupplyCrates.Aggregate("", (current, crate) => current + crate.Peek());
    }

    public override string PartTwo()
    {
        var crateMover = new CrateMover9001(PreparedInput.SupplyCrates);
        
        foreach (var instruction in PreparedInput.Instructions)
        {
            crateMover.ReadInstruction(instruction);
        }

        return PreparedInput.SupplyCrates.Aggregate("", (current, crate) => current + crate.Peek());
    }
    
    public override void Run()
    {
        Console.WriteLine(PuzzleTitle);
        
        Console.Write("Solution Part One: ");
        Console.WriteLine(PartOne());

        Preprocess(new PuzzleInput(Filename));
        Console.Write("Solution Part Two: ");
        Console.WriteLine(PartTwo());
    }

    public override void Preprocess(IPuzzleInput input, int part = 1)
    {
        var lines = input.GetAllLines().Reverse().ToList();
        var instructions = new Stack<Instruction>();
        
        int i;
        for (i = 0; !string.IsNullOrEmpty(lines[i]); i++)
        {
            var s = lines[i].Split(' ');
            instructions.Push(new Instruction()
            {
                Count = int.Parse(s[1]),
                From = int.Parse(s[3])-1,
                To = int.Parse(s[5])-1
            });
        }

        var numCrates = int.Parse(lines[i + 1].Trim().Split(' ')[^1]);
        
        var supplyCrates = new Stack<char>[numCrates];
        for (var j = 0; j < supplyCrates.Length; j++)
        {
            supplyCrates[j] = new Stack<char>();
        }
        
        for (var j = i+2; j < lines.Count; j++)
        {
            for (var k = 0; k < numCrates; k++)
            {
                var crate = lines[j].Substring(1+k*4, 1)[0];
                if (!crate.Equals(' '))
                {
                    supplyCrates[k].Push(crate);
                }
            }
        }
        PreparedInput = (supplyCrates, instructions);
    }

    private abstract class CrateMover
    {
        protected readonly Stack<char>[] SupplyCrates;

        protected CrateMover(Stack<char>[] supplyCrates)
        {
            SupplyCrates = supplyCrates;
        }

        public void ReadInstruction(Instruction instruction)
        {
            MoveCrates(instruction.Count, instruction.From, instruction.To);
        }

        protected abstract void MoveCrates(int count, int from, int to);
    }

    private class CrateMover9000 : CrateMover
    {
        public CrateMover9000(Stack<char>[] supplyCrates) : base(supplyCrates) { }

        protected override void MoveCrates(int count, int from, int to)
        {
            for (var i = 0; i < count; i++)
            {
                var crate = SupplyCrates[from].Pop();
                SupplyCrates[to].Push(crate);
            }
        }
    }
    
    private class CrateMover9001 : CrateMover
    {
        public CrateMover9001(Stack<char>[] supplyCrates) : base(supplyCrates) { }

        protected override void MoveCrates(int count, int from, int to)
        {
            var cratesToMove = new Stack<char>();
            for (var i = 0; i < count; i++)
            {
                cratesToMove.Push(SupplyCrates[from].Pop());
            }
            
            for (var i = 0; i < count; i++)
            {
                SupplyCrates[to].Push(cratesToMove.Pop());
            }
        }
    }
}