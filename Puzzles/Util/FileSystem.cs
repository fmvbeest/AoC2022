using System.ComponentModel;

namespace AoC2022.Util;

public interface INode
{
    public string Name { get; set; }

    public bool IsDirectory();

    public bool IsRoot();

    public Directory? GetParent();
}

public class Directory : INode
{
    public string Name { get; set; }
    private readonly bool _isDirectory;

    private readonly Directory? _parent;

    private readonly List<Directory> _directories;
    private readonly List<File> _files;

    public Directory(string name, Directory parent)
    {
        Name = name;
        _isDirectory = true;
        _directories = new List<Directory>();
        _files = new List<File>();
        _parent = parent;
    }

    public bool IsDirectory()
    {
        return _isDirectory;
    }

    public bool IsRoot()
    {
        return (_parent == null);
    }

    public Directory? GetParent()
    {
        return _parent;
    }

    public void AddDir(Directory directory)
    {
        _directories.Add(directory);
    }

    public void AddFile(File file)
    {
        _files.Add(file);
    }
    
    public IEnumerable<INode> GetDirectories()
    {
        return _directories;
    }

    public bool ContainsDirectory(string name)
    {
        return _directories.Any(node => node.Name.Equals(name));
    }

    public Directory? GetDirectory(string name)
    {
        Directory res = null;
        foreach (var dir in _directories.Where(node => node.Name.Equals(name)))
        {
            res = dir;
        }

        return res;
    }

    public long Size()
    {
        long size = _files.Sum(file => file.Size);

        foreach (var dir in _directories)
        {
            size += dir.Size();
        }

        return size;
    }

    public List<Directory> ListDirectories(List<Directory> list)
    {
        foreach (var dir in _directories)
        {
            list.Add(dir);
            dir.ListDirectories(list);
        }

        return list;
    }

}

public class File : INode
{
    public string Name { get; set; }
    private readonly bool _isDirectory;

    private readonly Directory? _parent;
    public long Size { get; set; }
    
    public File(string name, long size, Directory parent)
    {
        Name = name;
        Size = size;
        _parent = parent;
        _isDirectory = false;
    }
    
    public bool IsDirectory()
    {
        return _isDirectory;
    }

    public bool IsRoot()
    {
        return (_parent == null);
    }

    public Directory? GetParent()
    {
        return _parent;
    }
}