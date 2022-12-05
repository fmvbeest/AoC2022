using System.ComponentModel;

namespace AoC2022.Puzzles;

public class Puzzle5 : PuzzleBase
{
    protected override string Filename => "Input/puzzle-input-05";
    protected override string PuzzleTitle => "--- Day 5:  ---";
    
    public override int PartOne(IPuzzleInput input)
    {
        var (crates, instructions) = Preprocess(input);

        foreach (var instruction in instructions)
        {
            for (var i =0; i < instruction.Count; i++)
            {
                var crate = crates[instruction.From-1].Pop();
                crates[instruction.To-1].Push(crate);
            }
        }

        foreach (var crate in crates)
        {
            Console.Write($"{crate.Peek()}");
        }
        Console.WriteLine();
        
        return 0;
    }

    public override int PartTwo(IPuzzleInput input)
    {
        var (crates, instructions) = Preprocess(input);

        foreach (var instruction in instructions)
        {
            var cratesToMove = new Stack<char>();
            for (var i = 0; i < instruction.Count; i++)
            {
                cratesToMove.Push(crates[instruction.From-1].Pop());
            }
            
            for (var i = 0; i < instruction.Count; i++)
            {
                crates[instruction.To-1].Push(cratesToMove.Pop());
            }
        }

        foreach (var crate in crates)
        {
            Console.Write($"{crate.Peek()}");
        }
        Console.WriteLine();
        
        return 0;
    }
    
    private static (Stack<char>[], Stack<Instruction>) Preprocess(IPuzzleInput input)
    {
        var lines = input.GetAllLines().Reverse().ToList();
        var instructions = new Stack<Instruction>();
        int i;
        for (i = 0; !string.IsNullOrEmpty(lines[i]); i++)
        {
            var s = lines[i].Split(' ');
            Console.WriteLine($"({s}) ({s.Length})");
            var count = s[1];
            var from = s[3];
            var to = s[5];
            Console.Write($"({count}) ({from}) ({to})");
            Console.WriteLine();
            instructions.Push(new Instruction()
            {
                Count = int.Parse(count),
                From = int.Parse(from),
                To = int.Parse(to)
            });
        }

        var numCrates = int.Parse(lines[i + 1].Trim().Split(' ')[^1]);
        Console.WriteLine($"----- {numCrates}");

        var crates = new Stack<char>[numCrates];
        for (int n = 0; n < crates.Length; n++)
        {
            crates[n] = new Stack<char>();
        }
        
        for (int j = i+2; j < lines.Count; j++)
        {
            var s = lines[j];
            for (int k = 0; k < numCrates; k++)
            {
                var crate = s.Substring(1+k*4, 1)[0];
                if (!crate.Equals(' '))
                {
                    crates[k].Push(crate);
                }
            }
        }
        return (crates, instructions);
    }

    private class Instruction
    {
        public int Count { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}