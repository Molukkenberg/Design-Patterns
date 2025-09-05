namespace DesignPatterns.Structural_Patterns.Composite;

public class CompositeExample
{
    /// <summary>
    /// This method is equivalent to a consuming client.
    /// This method demonstrates the Composite design pattern by creating a tree structure of components
    /// </summary>
    public static void Run()
    {
        // Create composite nodes
        Composite composite1 = new();
        Composite composite2 = new();

        // Create leaf nodes
        Leaf leaf1 = new();
        Leaf leaf2 = new();
        Leaf leaf3 = new();

        // Build the tree structure
        composite1.Add(leaf1);
        composite1.Add(leaf2);
        composite1.Add(composite2);

        composite2.Add(leaf3);

        // Perform operation on the root composite
        composite1.Operation();
    }
}