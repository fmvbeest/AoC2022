namespace AoC2022.Util;

public class Coordinate : IEquatable<Coordinate>
{
    private readonly (int, int) _pos;

    public Coordinate(int x, int y)
    {
        _pos = (x, y);
    }
        
    public int X => _pos.Item1;

    public int Y => _pos.Item2;

    public bool Equals(Coordinate? other)
    {
        return other != null && X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj) => Equals(obj as Coordinate);

    public override int GetHashCode() => _pos.GetHashCode();

    public override string ToString() => $"({X},{Y})";

    public static Coordinate operator +(Coordinate a) => a;
    public static Coordinate operator -(Coordinate a) => new(-a.X, -a.Y);
    public static Coordinate operator +(Coordinate a, Coordinate b) => new(a.X + b.X, a.Y + b.Y);
    public static Coordinate operator -(Coordinate a, Coordinate b) => a + (-b);

    public bool IsAdjacentTo(Coordinate x)
    {
        var diff = this - x;
        if (diff.X == diff.Y && diff.X is 0 or 1)
        {
            return true;
        }

        return diff is { X: 0, Y: 1 } or { X: 1, Y: 0 } or { X: 0, Y: -1 } or { X: -1, Y: 0 };
    }

}