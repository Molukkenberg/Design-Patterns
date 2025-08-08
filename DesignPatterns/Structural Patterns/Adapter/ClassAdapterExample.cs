using DesignPatterns.Adapter;

namespace DesignPatterns.Structural_Patterns.Adapter;

public class ClassAdapterExample
{
    public static void Run()
    {
        // The client code supports the Target interface.
        ITarget target = new ClassAdapter();
        target.Request();
    }
}

// The Class Adapter inherits from Adaptee and implements the ITarget interface.
public class ClassAdapter : Adaptee, ITarget
{
    public void Request()
    {
        // The call is forwarded to the base class method.
        SpecificRequest();
    }
}