using DesignPatterns.Structural_Patterns.Decorator;

namespace DesignPatterns.Tests;

[TestClass]
public class Decorator_Tests
{
    [TestMethod]
    public void CascadeRequest_FullSequence()
    {
        // Arrange (C(B(A(Core))))
        IComponent chain =
            new ConcreteDecoratorC(
                new ConcreteDecoratorB(
                    new ConcreteDecoratorA(
                        new ConcreteComponent())));

        StringWriter stringWriter = new();
        TextWriter original = Console.Out;
        Console.SetOut(stringWriter);

        try
        {
            // Act
            chain.Operation();
        }
        finally
        {
            Console.SetOut(original);
        }

        string[] actual = stringWriter.ToString()
            .Replace("\r", string.Empty)
            .Split('\n', StringSplitOptions.RemoveEmptyEntries);

        string[] expected =
        [
            "ConcreteDecoratorC: Added Behavior",
            "ConcreteDecoratorB: Added Behavior",
            "ConcreteDecoratorA: Added Behavior",
            "Core"
        ];

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void CascadeRequest_Different_Construction()
    {
        // Arrange
        ConcreteComponent concreteComponent = new();

        ConcreteDecoratorA concreteDecoratorA = new(concreteComponent);
        ConcreteDecoratorB concreteDecoratorB = new(concreteDecoratorA);
        ConcreteDecoratorC concreteDecoratorC = new(concreteDecoratorB);

        StringWriter stringWriter = new();
        TextWriter original = Console.Out;
        Console.SetOut(stringWriter);

        try
        {
            // Act
            concreteDecoratorC.Operation();
        }
        finally
        {
            Console.SetOut(original);
        }

        string[] actual = stringWriter.ToString()
            .Replace("\r", string.Empty)
            .Split('\n', StringSplitOptions.RemoveEmptyEntries);

        string[] expected =
        [
            "ConcreteDecoratorC: Added Behavior",
            "ConcreteDecoratorB: Added Behavior",
            "ConcreteDecoratorA: Added Behavior",
            "Core"
        ];

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
