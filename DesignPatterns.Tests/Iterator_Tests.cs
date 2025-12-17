using DesignPatterns.Behavioral_Patterns.Iterator;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace DesignPatterns.Tests;

[TestClass]
public class Iterator_Tests
{
    [TestMethod]
    public void ForwardIteration_ShouldTraverseAllItems()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");
        aggregate.AddItem("Item 3");

        var iterator = aggregate.CreateIterator();

        // Act & Assert
        Assert.AreEqual("Item 1", iterator.First());
        Assert.IsFalse(iterator.IsDone());

        Assert.AreEqual("Item 2", iterator.Next());
        Assert.IsFalse(iterator.IsDone());

        Assert.AreEqual("Item 3", iterator.Next());
        Assert.IsFalse(iterator.IsDone());

        string beyondEnd = iterator.Next();
        Assert.IsNull(beyondEnd);
        Assert.IsTrue(iterator.IsDone());
    }

    [TestMethod]
    public void BackwardIteration_ShouldTraverseAllItemsInReverse()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");
        aggregate.AddItem("Item 3");

        var iterator = aggregate.CreateIterator();

        // Act & Assert
        Assert.AreEqual("Item 3", iterator.Last());
        Assert.IsFalse(iterator.IsDone());

        Assert.AreEqual("Item 2", iterator.Previous());
        Assert.IsFalse(iterator.IsDone());

        Assert.AreEqual("Item 1", iterator.Previous());
        Assert.IsFalse(iterator.IsDone());

        var beforeStart = iterator.Previous();
        Assert.IsNull(beforeStart);
        Assert.IsTrue(iterator.IsDone());
    }

    [TestMethod]
    public void CurrentItem_ShouldReturnCurrentElementWithoutMoving()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");

        var iterator = aggregate.CreateIterator();

        // Act & Assert
        iterator.First();
        Assert.AreEqual("Item 1", iterator.CurrentItem());
        Assert.AreEqual("Item 1", iterator.CurrentItem()); 

        iterator.Next();
        Assert.AreEqual("Item 2", iterator.CurrentItem());
        Assert.AreEqual("Item 2", iterator.CurrentItem()); // Should not move
    }

    [TestMethod]
    public void EmptyCollection_ShouldReturnNullAndIsDoneTrue()
    {
        // Arrange
        ConcreteAggregate<string> emptyAggregate = new();
        var iterator = emptyAggregate.CreateIterator();

        // Act & Assert
        Assert.IsNull(iterator.First());
        Assert.IsTrue(iterator.IsDone());

        Assert.IsNull(iterator.Last());
        Assert.IsTrue(iterator.IsDone());

        Assert.IsNull(iterator.CurrentItem());
        Assert.IsTrue(iterator.IsDone());
    }

    [TestMethod]
    public void MultipleIterators_ShouldBeIndependent()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");
        aggregate.AddItem("Item 3");

        IIterator<string> iterator1 = aggregate.CreateIterator();
        IIterator<string> iterator2 = aggregate.CreateIterator();

        // Act
        iterator1.First();
        iterator2.Last();

        // Assert
        Assert.AreEqual("Item 1", iterator1.CurrentItem());
        Assert.AreEqual("Item 3", iterator2.CurrentItem());

        iterator1.Next();
        Assert.AreEqual("Item 2", iterator1.CurrentItem());
        Assert.AreEqual("Item 3", iterator2.CurrentItem()); 
    }

    [TestMethod]
    public void IsDone_BeforeInitialization_ShouldReturnTrue()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");

        IIterator<string> iterator = aggregate.CreateIterator();

        // Act & Assert
        Assert.IsTrue(iterator.IsDone()); 
        Assert.IsNull(iterator.CurrentItem());
    }

    [TestMethod]
    public void BoundaryConditions_NextBeyondEnd_ShouldReturnNullAndIsDoneTrue()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");

        IIterator<string> iterator = aggregate.CreateIterator();

        // Act
        iterator.First();
        string item = iterator.Next(); // Beyond end

        // Assert
        Assert.IsNull(item);
        Assert.IsTrue(iterator.IsDone());
        Assert.IsNull(iterator.CurrentItem());
    }

    [TestMethod]
    public void BoundaryConditions_PreviousBeforeStart_ShouldReturnNullAndIsDoneTrue()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");

        IIterator<string> iterator = aggregate.CreateIterator();

        // Act
        iterator.First();
        string item = iterator.Previous(); // Before start

        // Assert
        Assert.IsNull(item);
        Assert.IsTrue(iterator.IsDone());
        Assert.IsNull(iterator.CurrentItem());
    }

    [TestMethod]
    public void GenericType_Int_ShouldWorkCorrectly()
    {
        // Arrange
        ConcreteAggregate<int> aggregate = new();
        aggregate.AddItem(10);
        aggregate.AddItem(20);
        aggregate.AddItem(30);

        IIterator<int> iterator = aggregate.CreateIterator();

        // Act & Assert
        Assert.AreEqual(10, iterator.First());
        Assert.AreEqual(20, iterator.Next());
        Assert.AreEqual(30, iterator.Next());
    }

    [TestMethod]
    public void GenericType_CustomObject_ShouldWorkCorrectly()
    {
        // Arrange
        var obj1 = new TestObject { Id = 1, Name = "First" };
        var obj2 = new TestObject { Id = 2, Name = "Second" };

        ConcreteAggregate<TestObject> aggregate = new();
        aggregate.AddItem(obj1);
        aggregate.AddItem(obj2);

        var iterator = aggregate.CreateIterator();

        // Act & Assert
        Assert.AreEqual(obj1, iterator.First());
        Assert.AreEqual(obj2, iterator.Next());
    }

    [TestMethod]
    public void InterleavedTraversal_ShouldWorkCorrectly()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");
        aggregate.AddItem("Item 3");

        IIterator<string> forwardIterator = aggregate.CreateIterator();
        IIterator<string> backwardIterator = aggregate.CreateIterator();

        // Act & Assert
        forwardIterator.First();
        backwardIterator.Last();

        Assert.AreEqual("Item 1", forwardIterator.CurrentItem());
        Assert.AreEqual("Item 3", backwardIterator.CurrentItem());

        forwardIterator.Next();
        backwardIterator.Previous();

        Assert.AreEqual("Item 2", forwardIterator.CurrentItem());
        Assert.AreEqual("Item 2", backwardIterator.CurrentItem());

        forwardIterator.Next();
        backwardIterator.Previous();

        Assert.AreEqual("Item 3", forwardIterator.CurrentItem());
        Assert.AreEqual("Item 1", backwardIterator.CurrentItem());
    }

    [TestMethod]
    public void SingleItem_ShouldHandleCorrectly()
    {
        // Arrange
        ConcreteAggregate<string> aggregate = new();
        aggregate.AddItem("Only Item");

        var iterator = aggregate.CreateIterator();

        // Act & Assert
        Assert.AreEqual("Only Item", iterator.First());
        Assert.IsFalse(iterator.IsDone());

        Assert.AreEqual("Only Item", iterator.Last());
        Assert.IsFalse(iterator.IsDone());

        Assert.IsNull(iterator.Next());
        Assert.IsTrue(iterator.IsDone());
    }

    // Helper class for custom object test
    private class TestObject
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
