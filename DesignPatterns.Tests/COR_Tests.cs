using DesignPatterns.Behavioral_Patterns.ChainOfResponsibility;

namespace DesignPatterns.Tests;

[TestClass]
public class ChainOfResponsibility_Tests
{
    [TestMethod]
    public void Chain_Handles_Known_Requests_And_Leaves_Unknown_Unhandled()
    {
        // Arrange: setup chain handler1 -> handler2
        var handler1 = new ConcreteHandler1();
        var handler2 = new ConcreteHandler2();
        handler1.SetNext(handler2);

        // Act
        var result1 = handler1.Handle("Request1");
        var result2 = handler1.Handle("Request2");
        var result3 = handler1.Handle("Request3"); // no handler for Request3

        // Assert
        Assert.AreEqual("ConcreteHandler1 handled Request1", result1);
        Assert.AreEqual("ConcreteHandler2 handled Request2", result2);
        Assert.IsNull(result3);
    }

    [TestMethod]
    public void Chain_Delegates_To_Next_Handler_When_First_Cannot_Handle()
    {
        // Arrange: handler1 cannot handle Request2; should delegate to handler2
        var handler1 = new ConcreteHandler1();
        var handler2 = new ConcreteHandler2();
        handler1.SetNext(handler2);

        // Act
        var result = handler1.Handle("Request2");

        // Assert
        Assert.AreEqual("ConcreteHandler2 handled Request2", result);
    }
}
