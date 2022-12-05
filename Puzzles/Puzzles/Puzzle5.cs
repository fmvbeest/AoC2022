﻿using System.ComponentModel;

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
            for (var i = 0; i < instruction.Count; i++)
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
            instructions.Push(new Instruction()
            {
                Count = int.Parse(s[1]),
                From = int.Parse(s[3]),
                To = int.Parse(s[5])
            });
        }

        var numCrates = int.Parse(lines[i + 1].Trim().Split(' ')[^1]);
        
        var crates = new Stack<char>[numCrates];
        for (var j = 0; j < crates.Length; j++)
        {
            crates[j] = new Stack<char>();
        }
        
        for (var j = i+2; j < lines.Count; j++)
        {
            for (var k = 0; k < numCrates; k++)
            {
                var crate = lines[j].Substring(1+k*4, 1)[0];
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
        public int Count { get; init; }
        public int From { get; init; }
        public int To { get; init; }
    }
}