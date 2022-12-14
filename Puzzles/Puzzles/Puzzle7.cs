using Directory = AoC2022.Util.Directory;
using File = AoC2022.Util.File;

namespace AoC2022.Puzzles;

public class Puzzle7 : PuzzleBase<Directory, long, long>
{
    protected override string Filename => "Input/puzzle-input-07";
    protected override string PuzzleTitle => "--- Day 7: No Space Left On Device ---";

    public override long PartOne(Directory root)
    {
        return root.ListDirectories(new List<Directory> {root}).Select(dir => dir.Size()).Where(size => size <= 100000).Sum();
    }

    public override long PartTwo(Directory root)
    {
        var spaceToFreeUp = 30000000 - (70000000 - root.Size());
        return root.ListDirectories(new List<Directory>{root}).Select(dir => dir.Size()).Where(size => size >= spaceToFreeUp).Min();
    }
    
    public override Directory Preprocess(IPuzzleInput input, int part = 1)
    {
        var lines = input.GetAllLines().ToArray();

        var root = new Directory("/", null);
        var current = root;

        foreach (var line in lines)
        {
            current = line[0] == '$' ? ProcessCommand(line, current, root) : AddContent(line, current);
        }

        return root;
    }

    private static Directory ProcessCommand(string cmd, Directory current, Directory root)
    {
        var s = cmd.Split(' ');
        if (!s[1].Equals("cd")) return current;
        switch (s[2])
        {
            case "/":
                current = root;
                break;
            case "..":
                current = current.GetParent();
                break;
            default:
            {
                if (current.ContainsDirectory(s[2]))
                {
                    current = current.GetDirectory(s[2]);
                }
                break;
            }
        }

        return current;
    }

    private static Directory AddContent(string line, Directory current)
    {
        var s = line.Split(' ');
        if (s[0] == "dir")
        {
            current.AddDir(new Directory(s[1], current));
        }
        else
        {
            current.AddFile(new File(s[1], long.Parse(s[0]), current));
        }
        return current;
    }
}