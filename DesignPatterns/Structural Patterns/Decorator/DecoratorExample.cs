namespace DesignPatterns.Structural_Patterns.Decorator;

/// <summary>
/// Client code / Example
/// </summary>
public static class DecoratorExample
{
    public static void ClientCode()
    {
        ConcreteComponent concreteComponent = new();

        ConcreteDecoratorA concreteDecoratorA = new(concreteComponent);
        ConcreteDecoratorB concreteDecoratorB = new(concreteDecoratorA);
        ConcreteDecoratorC concreteDecoratorC = new(concreteDecoratorB);

        concreteDecoratorC.Operation();
    }
}

