namespace AoC2022.Puzzles;

public class Puzzle5 : PuzzleBase<string>
{
    protected override string Filename => "Input/puzzle-input-05";
    protected override string PuzzleTitle => "--- Day 5:  ---";
    
    public override string PartOne(IPuzzleInput input)
    {
        var (supplyCrates, instructions) = Preprocess(input);

        var crateMover = new CrateMover9000(supplyCrates);
        
        foreach (var instruction in instructions)
        {
            crateMover.ReadInstruction(instruction);
        }

        return supplyCrates.Aggregate("", (current, crate) => current + crate.Peek());
    }

    public override string PartTwo(IPuzzleInput input)
    {
        var (supplyCrates, instructions) = Preprocess(input);

        var crateMover = new CrateMover9001(supplyCrates);
        
        foreach (var instruction in instructions)
        {
            crateMover.ReadInstruction(instruction);
        }

        return supplyCrates.Aggregate("", (current, crate) => current + crate.Peek());
    }
    
    private static (Stack<char>[], Stack<Instruction>) Preprocess(IPuzzleInput input)
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
        return (supplyCrates, instructions);
    }

    private class Instruction
    {
        public int Count { get; init; }
        public int From { get; init; }
        public int To { get; init; }
    }

    private interface ICrateMover
    {
        public void ReadInstruction(Instruction instruction);
    }

    private class CrateMover9000 : ICrateMover
    {
        private readonly Stack<char>[] _supplyCrates;

        public CrateMover9000(Stack<char>[] supplyCrates)
        {
            _supplyCrates = supplyCrates;
        }

        public void ReadInstruction(Instruction instruction)
        {
            for (var i = 0; i < instruction.Count; i++)
            {
                var crate = _supplyCrates[instruction.From].Pop();
                _supplyCrates[instruction.To].Push(crate);
            }
        }
    }
    
    private class CrateMover9001 : ICrateMover
    {
        private readonly Stack<char>[] _supplyCrates;

        public CrateMover9001(Stack<char>[] supplyCrates)
        {
            _supplyCrates = supplyCrates;
        }

        public void ReadInstruction(Instruction instruction)
        {
            var cratesToMove = new Stack<char>();
            for (var i = 0; i < instruction.Count; i++)
            {
                cratesToMove.Push(_supplyCrates[instruction.From].Pop());
            }
            
            for (var i = 0; i < instruction.Count; i++)
            {
                _supplyCrates[instruction.To].Push(cratesToMove.Pop());
            }
        }
    }
    
}