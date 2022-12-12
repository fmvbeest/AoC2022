using AoC2022.Util;

namespace AoC2022.Puzzles;

public class Puzzle11 : PuzzleBase<IEnumerable<Monkey>, int, long>
{
    protected override string Filename => "Input/puzzle-input-11";
    protected override string PuzzleTitle => "--- Day 11: Monkey in the Middle ---";

    public override int PartOne(IEnumerable<Monkey> input)
    {
        var monkeys = input.ToList();

        var rounds = 0;

        while (rounds < 20)
        {
            rounds++;
            for (var i = 0; i < monkeys.Count; i++)
            {
                while (monkeys[i].HasItems())
                {
                    var (item, throwTo) = monkeys[i].Turn();

                    monkeys[throwTo].Items.Enqueue(item);                    
                }
            }
        }
        
        var inspections = monkeys.OrderByDescending(x => x.Inspections()).Take(2).Select(x => x.Inspections()).ToArray();
        return inspections[0] * inspections[1];
    }

    public override long PartTwo(IEnumerable<Monkey> input)
    {
        var monkeys = input.ToList();

        var rounds = 0;

        var modulus = monkeys[0].Modulus;
        for (int i = 1; i < monkeys.Count; i++)
        {
            modulus *= monkeys[i].Modulus;
        }
        
        while (rounds < 10000)
        {
            rounds++;
            for (var i = 0; i < monkeys.Count; i++)
            {
                while (monkeys[i].HasItems())
                {
                    var (item, throwTo) = monkeys[i].Turn(2);

                    monkeys[throwTo].Items.Enqueue(item % modulus);                    
                }
            }
        }

        var inspections = monkeys.OrderByDescending(x => x.Inspections()).Take(2).Select(x => Convert.ToInt64(x.Inspections())).ToArray();
        return inspections[0] * inspections[1];
    }
    
    public override IEnumerable<Monkey> Preprocess(IPuzzleInput input, int part = 1)
    {
        var list = new List<Monkey>();

        var monkeys = input.GetText().Split(Environment.NewLine+Environment.NewLine);
        
        foreach (var monkeyData in monkeys)
        {
            list.Add(ParseMonkey(monkeyData));
        }

        return list;
    }

    private Monkey ParseMonkey(string data)
    {
        var s = data.Split(Environment.NewLine);
        var id = int.Parse(s[0].Split(' ')[1][0].ToString());
        var items = s[1].Split(':')[^1].Split(", ").Select(x => (long)int.Parse(x)).ToList();
        var operation = ParseOperation(s[2].Split(':')[^1].Trim());
        var modulus = int.Parse(s[3].Split(' ')[^1]);
        var throwTrue = int.Parse(s[4].Split(' ')[^1]);
        var throwFalse = int.Parse(s[5].Split(' ')[^1]);

        var monkey = new Monkey(id, items, throwTrue, throwFalse, modulus, operation);
        
        return monkey;
    }

    private Func<long, long> ParseOperation(string operation)
    {
        var s = operation.Split('=')[^1].Trim().Split(' ');
        var op = s[1];
        Func<long, long> fun;
        if (s[2] == "old")
        {
            fun = op switch
            {
                "*" => i => i * i,
                "+" => i => i + i,
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, "Unexpected operator")
            };
        }
        else
        {
            var x = int.Parse(s[2]);
            fun = op switch
            {
                "*" => i => i * x,
                "+" => i => i + x,
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, "Unexpected operator")
            };
        }

        return fun;
    }
}