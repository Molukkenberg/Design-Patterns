namespace DesignPatterns.Structural_Patterns.Composite;

/*
 * Purpose: Compose objects into tree structures to represent part-whole hierarchies.
 * The Composite pattern lets clients treat individual objects and compositions of objects uniformly.
 */

public interface IComponent
{
    /// <summary>
    /// Operation that can be performed on both leaf and composite nodes.
    /// </summary>
    void Operation();
}

/// <summary>
/// A Leaf is a basic element of a structure that cannot have any children.
/// </summary>
public class Leaf : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Leaf operation");
    }
}

/// <summary>
/// Composite is a node that has children but doesn't know the concrete classes of those children.
/// </summary>
public class Composite : IComponent
{
    private readonly List<IComponent> _children = [];

    public void Operation()
    {
        Console.WriteLine("Composite operation");

        foreach (IComponent child in _children)
        {
            child.Operation();
        }
    }

    public void Add(IComponent component) => _children.Add(component);

    public void Remove(IComponent component) => _children.Remove(component);

    public IComponent GetChild(int index) => _children[index];
}
