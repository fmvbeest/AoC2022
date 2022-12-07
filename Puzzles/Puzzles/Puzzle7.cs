using AoC2022.Util;
using Directory = AoC2022.Util.Directory;

namespace AoC2022.Puzzles;

public class Puzzle7 : PuzzleBase<long, INode>
{
    protected override string Filename => "Input/puzzle-input-07";
    protected override string PuzzleTitle => "--- Day 7: ---";

    public override long PartOne(INode root)
    {
        return 0;
    }

    public override long PartTwo(INode root)
    {
        return 0;
    }
    
    public override INode Preprocess(IPuzzleInput input, int part = 1)
    {
        INode root = new Directory("/");
        
        return new Directory("/");
    }
}