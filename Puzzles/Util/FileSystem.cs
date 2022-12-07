namespace AoC2022.Util;

public interface INode
{
    public string Name { get; set; }
    
    public bool IsDirectory { get; set; }
}

public class Directory : INode
{
    public string Name { get; set; }
    public bool IsDirectory { get; set; }

    private readonly List<INode> _nodes;
    
    public Directory(string name)
    {
        Name = name;
        IsDirectory = true;
        _nodes = new List<INode>();
    }

    public void AddNode(INode node)
    {
        _nodes.Add(node);
    }
    
    public IEnumerable<INode> GetNodes()
    {
        return _nodes;
    }

}

public class File : INode
{
    public string Name { get; set; }
    public bool IsDirectory { get; set; }
    
    public long Size { get; set; }

    public File(string name)
    {
        Name = name;
        IsDirectory = false;
    }
}