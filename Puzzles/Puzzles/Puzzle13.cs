using System.Data;
using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle13 : PuzzleBase<IEnumerable<(List<object> left, List<object> right)>, int, int>
{
    protected override string Filename => "Input/puzzle-input-13";
    protected override string PuzzleTitle => "--- Day 13: Distress Signal ---";

    public override int PartOne(IEnumerable<(List<object> left, List<object> right)> input)
    {
        var pairs = input.ToList();
        
        var sum = 0;
        for (var i = 0; i < pairs.Count; i++)
        {
            if (Compare(pairs[i].left, pairs[i].right) < 0)
            {
                sum += i + 1;
            }
        }

        return sum;
    }

    public override int PartTwo(IEnumerable<(List<object> left, List<object> right)> input)
    {
        var pairs = input.ToList();
        var two = ParsePacket("[[2]]");
        var six = ParsePacket("[[6]]");
        pairs.Add((two, six));
        
        var list = new List<object>();
        foreach (var pair in pairs)
        {
            list.Add(pair.left);
            list.Add(pair.right);
        }
        
        list.Sort(Compare);

        return (list.IndexOf(two) + 1) * (list.IndexOf(six) + 1);
    }
    
    public override IEnumerable<(List<object> left, List<object> right)> Preprocess(IPuzzleInput input, int part = 1)
    {
        var x = input.GetText().Split(Environment.NewLine+Environment.NewLine);

        return x.Select(set => set.Split(Environment.NewLine))
            .Select(pair => (ParsePacket(pair[0]), ParsePacket(pair[1]))).ToList();
    }

    private int Compare(object left, object right)
    {
        if (left is int x && right is int y)
        {
            return x.CompareTo(y);
        }

        using var leftList = GetList(left).GetEnumerator();
        using var rightList = GetList(right).GetEnumerator();

        while (true)
        {
            var leftHasItem = leftList.MoveNext();
            var rightHasItem = rightList.MoveNext();

            switch (leftHasItem)
            {
                case false when !rightHasItem:
                    return 0;
                case false when rightHasItem:
                    return -1;
                case true when !rightHasItem:
                    return 1;
            }

            var compare = Compare(leftList.Current, rightList.Current);
            if (compare != 0)
            {
                return compare;
            }
        }
    }

    private List<object> GetList(object o)
    {
        return o as List<object> ?? new List<object> { o };
    }

    private List<object> ParsePacket(string s)
    {
        var stack = new Stack<List<object>>();
        stack.Push(new List<object>());
        const char sep = '#';
        var numberOrSeparator = s.Replace('[', sep).Replace(']', sep).Replace(',', sep);
        for (var i = 1; i < s.Length - 1; i++)
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