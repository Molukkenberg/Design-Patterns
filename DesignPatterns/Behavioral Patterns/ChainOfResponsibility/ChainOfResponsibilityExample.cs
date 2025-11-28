namespace DesignPatterns.Behavioral_Patterns.ChainOfResponsibility;

public class ChainOfResponsibilityExample
{
    public static void Run()
    {
        // Setup Chain of Responsibility
        var handler1 = new ConcreteHandler1();
        var handler2 = new ConcreteHandler2();

        handler1.SetNext(handler2);

        // Generate requests
        var requests = new[] { "Request1", "Request2", "Request3" };

        foreach (var request in requests)
        {
            Console.WriteLine($"Client: Who wants to handle {request}?");

            var result = handler1.Handle(request);

            if (result != null)
            {
                Console.WriteLine($"  {result}");
            }
            else
            {
                Console.WriteLine($"  {request} was left unhandled.");
            }
        }
    }
}
