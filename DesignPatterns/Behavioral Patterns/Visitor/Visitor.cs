namespace DesignPatterns.Behavioral_Patterns.Visitor;

/// <summary>
/// Purpose:
///     - Represent an operation to be performed on the elements of an object structure.
///     - Visitor lets you define a new operation without changing the classes of the elements on which it operates.
///     
/// Applicability: Use the Visitor pattern when:
///     - You have an object structure with many distinct and unrelated operations to perform.
///     - You want to avoid "polluting" the classes of the elements with these operations.
///     - The classes of the elements rarely change, but you often need to define new operations.
/// 
/// Participants:
///     - Visitor: Declares a visit operation for each type of ConcreteElement in the object structure.
///     - ConcreteVisitor: Implements each operation declared by Visitor.
///     - Element: Defines an accept operation that takes a visitor as an argument.
///     - ConcreteElement: Implements the accept operation.
///     - ObjectStructure: Can enumerate its elements 
///                        May provide a high-level interface to allow the visitor to visit its elements.
///                        Can be a composite or a collection (such as a list).
///                        
/// Interactions:
///     - The client creates ConcreteVisitor objects and uses them to perform operations on the elements of the object structure.
///     - On being visited, an element calls the corresponding visit operation in the visitor for its own class.

///     
/// Remarks:
///     - Visitor makes use of "Double Dispatch" programming concept:
///       The operation that gets executed depends on both the type of the visitor 
///         and the type of the element being visited.
/// </summary>
public interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA element);
    void VisitConcreteElementB(ConcreteElementB element);
}

public class ConcreteVisitor1 : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine("ConcreteVisitor1: Visiting ConcreteElementA");
    }
    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine("ConcreteVisitor1: Visiting ConcreteElementB");
    }
}

public class ConcreteVisitor2 : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA element)
    {
        Console.WriteLine("ConcreteVisitor2: Visiting ConcreteElementA");
    }
    public void VisitConcreteElementB(ConcreteElementB element)
    {
        Console.WriteLine("ConcreteVisitor2: Visiting ConcreteElementB");
    }
}

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }
}

public class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }
}
