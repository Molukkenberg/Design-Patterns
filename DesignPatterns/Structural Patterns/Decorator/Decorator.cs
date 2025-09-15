namespace DesignPatterns.Structural_Patterns.Decorator;

/*
 * Also known as: Wrapper
 * 
 * Purpose: Attach additional responsibilities to an object dynamically.
 * The Decorator pattern lets clients add responsibilities to individual objects
 * without affecting the behavior of other objects from the same class.
 *
 * Applicability: Use the Decorator pattern when:
 * - You want to add responsibilities to individual objects dynamically and transparently, without affecting other objects.
 * - The responsibilities can be withdrawn.
 * - You need to add functionality to classes in a flexible and reusable way.
 */

public interface IComponent
{
    void Operation();
}

public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Core");
    }
}

public abstract class Decorator(IComponent component) : IComponent
{
    protected IComponent wrappee = component;

    public virtual void Operation() => wrappee.Operation();
}

public class ConcreteDecoratorA(IComponent component) : Decorator(component)
{
    public string AddedState { get; set; } = "ConcreteDecoratorA: Added Behavior";

    public override void Operation()
    {
        // Additional behavior for ConcreteDecoratorA

        Console.WriteLine(AddedState);

        wrappee.Operation();
    }
}

public class ConcreteDecoratorB(IComponent component) : Decorator(component)
{
    private static void AddedBehavior() => Console.WriteLine("ConcreteDecoratorB: Added Behavior");

    public override void Operation()
    {
        AddedBehavior();

        wrappee.Operation();
    }
}

/// <summary>
/// IDecorator interface, alternative to abstract class
/// </summary>
public interface IDecorator
{
    IComponent Wrappee { get; init; }
    void Operation();
}

public class ConcreteDecoratorC(IComponent component) : IDecorator, IComponent
{
    public IComponent Wrappee { get; init; } = component;

    public void Operation()
    {
        Console.WriteLine("ConcreteDecoratorC: Added Behavior");

        Wrappee.Operation();
    }
}
