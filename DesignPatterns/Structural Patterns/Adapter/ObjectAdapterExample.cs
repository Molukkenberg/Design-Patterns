using DesignPatterns.Adapter;

namespace DesignPatterns.Structural_Patterns.Adapter;

public class ObjectAdapterExample
{
    public static void Run()
    {
        // The client code supports the Target interface.
        ITarget target = new ObjectAdapter(new Adaptee());
        target.Request();
    }
}

// The Object Adapter uses composition to wrap the Adaptee.
public class ObjectAdapter(IAdaptee adaptee) : ITarget
{
    public void Request()
    {
        adaptee.SpecificRequest();
    }
}