using System.Data;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle13 : PuzzleBase<IEnumerable<(List<object> left, List<object> right)>, int, int>
{
    protected override string Filename => "Input/puzzle-input-13";
    protected override string PuzzleTitle => "--- Day 13: Distress Signal ---";

    public override int PartOne(IEnumerable<(List<object> left, List<object> right)> input)
    {
        return 0;
    }

    public override int PartTwo(IEnumerable<(List<object> left, List<object> right)> input)
    {
        return 0;
    }
    
    public override IEnumerable<(List<object> left, List<object> right)> Preprocess(IPuzzleInput input, int part = 1)
    {
        var res = new List<(List<object> left, List<object> right)>();
        var x = input.GetText().Split(Environment.NewLine+Environment.NewLine);

        foreach (var set in x)
        {
            var pair = set.Split(Environment.NewLine);
            res.Add((parsePacket(pair[0]), parsePacket(pair[1])));
        }

        return res;
    }

    public List<object> parsePacket(string s)
    {
         
        var stack = new Stack<List<object>>();
        stack.Push(new List<object>());
        const char sep = '#';
        var numberOrSeparator = s.Replace('[', sep).Replace(']', sep).Replace(',', sep);
        for (int i = 1; i < s.Length-1; i++)
        {
            switch (s[i])
            {
                case ',': break;
                case ']':
                    stack.Pop();
                    break;
                case '[':
                    var list = new List<object>();
                    stack.Peek().Add(list);
                    stack.Push(list);
                    break;
                default:
                    var end = numberOrSeparator.IndexOf(sep, i+1);
                    var sub = numberOrSeparator.Substring(i, end-i);
                    stack.Peek().Add(int.Parse(sub));
                    i = end-1;
                    break;
            }
        }
        
        return stack.Pop();
    }
    
}