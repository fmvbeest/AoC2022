using System.Runtime.CompilerServices;

namespace AoC2022.Util;

public class Monkey
{
    public readonly Queue<long> Items;
    private int _id;
    private readonly (int testTrue, int testFalse) _throwTo;
    
    private readonly Func<long, long> _operate;

    public readonly int Modulus;

    private int _inspections;

    public Monkey(int id, IEnumerable<long> items, int throwTrue, int throwFalse, int modulus, Func<long, long> operate)
    {
        _inspections = 0;
        _id = id;
        Modulus = modulus;
        _throwTo = (throwTrue, throwFalse);
        _operate = operate;
        Items = new Queue<long>(items);
    }

    private long Inspect(long item)
    {
        _inspections++;
        return _operate(item);
    }

    private static long Relief(long item)
    {
        return item/3;
    }

    public (long item, int throwTo) Turn(int part = 1)
    {
        var item = Items.Dequeue();
        item = Inspect(item);
        if (part == 1)
        {
            item = Relief(item);            
        }
        var throwTo = (item % Modulus == 0) ? _throwTo.testTrue : _throwTo.testFalse;
        return (item, throwTo);
    }

    public bool HasItems()
    {
        return Items.Count > 0;
    }

    public int Inspections()
    {
        return _inspections;
    }
}