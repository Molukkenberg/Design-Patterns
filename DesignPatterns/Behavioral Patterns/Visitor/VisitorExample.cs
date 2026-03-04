namespace DesignPatterns.Behavioral_Patterns.Visitor;

/// <summary>
/// Client / ObjectStructure
/// </summary>
public class VisitorExample
{
    public static void Main()
    {
        List<IElement> elements =
        [
            new ConcreteElementA(),
            new ConcreteElementB()
        ];

        IVisitor visitor1 = new ConcreteVisitor1();
        IVisitor visitor2 = new ConcreteVisitor2();

        foreach (var element in elements)
        {
            element.Accept(visitor1);
            element.Accept(visitor2);
        }
    }
}