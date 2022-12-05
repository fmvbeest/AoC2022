using System.ComponentModel;

namespace AoC2022.Puzzles;

public class Puzzle5 : PuzzleBase<string>
{
    protected override string Filename => "Input/puzzle-input-05";
    protected override string PuzzleTitle => "--- Day 5:  ---";
    
    public override string PartOne(IPuzzleInput input)
    {
        var (supplyCrates, instructions) = Preprocess(input);

        foreach (var instruction in instructions)
        {
            for (var i = 0; i < instruction.Count; i++)
            {
                var crate = supplyCrates[instruction.From-1].Pop();
                supplyCrates[instruction.To-1].Push(crate);
            }
        }

        return supplyCrates.Aggregate("", (current, crate) => current + crate.Peek());
    }

    public override string PartTwo(IPuzzleInput input)
    {
        var (supplyCrates, instructions) = Preprocess(input);

        foreach (var instruction in instructions)
        {
            var cratesToMove = new Stack<char>();
            for (var i = 0; i < instruction.Count; i++)
            {
                cratesToMove.Push(supplyCrates[instruction.From-1].Pop());
            }
            
            for (var i = 0; i < instruction.Count; i++)
            {
                supplyCrates[instruction.To-1].Push(cratesToMove.Pop());
            }
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
                From = int.Parse(s[3]),
                To = int.Parse(s[5])
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
}