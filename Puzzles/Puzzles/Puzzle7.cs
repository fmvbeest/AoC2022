using AoC2022.Util;
using Directory = AoC2022.Util.Directory;
using File = AoC2022.Util.File;

namespace AoC2022.Puzzles;

public class Puzzle7 : PuzzleBase<long, Directory>
{
    protected override string Filename => "Input/puzzle-input-07";
    protected override string PuzzleTitle => "--- Day 7: ---";

    public override long PartOne(Directory root)
    {
        var directories = root.ListDirectories(new List<Directory>(){root});

        return directories.Select(dir => dir.Size()).Where(dirsize => dirsize <= 100000).Sum();
    }

    public override long PartTwo(Directory root)
    {
        const int totalSize = 70000000;
        const int requiredSpace = 30000000;
        
        var spaceToFreeUp = requiredSpace - (totalSize - root.Size());
        
        var directories = root.ListDirectories(new List<Directory>(){root});

        var removeCandidates = directories.Select(d => d).Where(d => d.Size() >= spaceToFreeUp).ToList();

        return removeCandidates.Select(dir => dir.Size()).Prepend(totalSize).Min();
    }
    
    public override Directory Preprocess(IPuzzleInput input, int part = 1)
    {
        var lines = input.GetInput().ToArray();

        var root = new Directory("/", null);
        var current = root;

        foreach (var line in lines)
        {
            if (line[0] == '$')
            {
                //Console.WriteLine(line);
                var s = line.Split(' ');
                if (s[1].Equals("cd"))
                {
                    if (s[2].Equals("/"))
                    {
                        current = root;
                    } else if (s[2].Equals(".."))
                    {
                        //Console.WriteLine("Go up");
                        if (current.IsRoot())
                        {
                            Console.WriteLine("already in root");
                        }
                        else
                        {
                            current = current.GetParent();
                        }
                    }
                    else
                    {
                        //Console.WriteLine($"cd into {s[2]}");
                        if (!current.ContainsDirectory(s[2]))
                        {
                            //Console.WriteLine($"Directory {s[2]} does not exist.");
                        }
                        else
                        {
                            current = current.GetDirectory(s[2]);
                        }
                    }
                }
            }
            else
            {
                //Console.WriteLine(line);
                var s = line.Split(' ');
                if (s[0] == "dir")
                {
                    //Console.WriteLine($"Directory {s[1]}");
                    var dir = new Directory(s[1], current);
                    current.AddDir(dir);
                }
                else
                {
                    var file = new File(s[1], long.Parse(s[0]), current);
                    current.AddFile(file);
                }
            }
        }

        return root;
    }
}