using DesignPatterns.Behavioral_Patterns.Observer;

namespace DesignPatterns.Tests;

[TestClass]
public class Observer_Tests
{
    [TestMethod]
    public void Test_Observer_Pattern()
    {
        // Arrange
        ConcreteSubject subject = new();
        ConcreteObserver observer = new(subject);
        ConcreteObserver anotherObserver = new(subject);

        // Act & Assert
        subject.State = "New State";
        subject.Notify();
        Assert.AreEqual("New State", observer.Subject.State);

        subject.State = "Another State";
        Assert.AreEqual("Another State", anotherObserver.Subject.State);
    }

    [TestMethod]
    public void Test_Event_Observer()
    {
        // Arrange
        ConcreteEventSubject subject = new();
        ConcreteEventObserver observer = new(subject);

        // Act
        subject.State = "New Event State";  
        subject.Notify();

        // Assert
        Assert.AreEqual("New Event State", observer.Subject.State);
    }
}
