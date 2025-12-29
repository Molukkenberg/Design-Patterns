namespace DesignPatterns.Behavioral_Patterns.Mediator;

/// <summary>
/// Purpose: Define an object that encapsulates how a set of objects interact.
///          Mediator promotes loose coupling by keeping objects from referring to each other explicitly,
///          
/// Applicability: Use the Mediator pattern when
/// - Communication between a set of objects is complex and involves many interconnections.
/// - Reusing an object is difficult because it refers to and communicates with many other objects.
/// - Changeability of functionality, distributed between multiple classes, should be provided
///
/// Participants:
/// - Mediator: Declares an interface for communicating with Colleague objects.
/// - ConcreteMediator: Implements cooperative behavior by coordinating Colleague objects.
/// - Colleague classes: Each Colleague class knows its Mediator object. 
///                      Each Colleague communicates with its Mediator 
///                      whenever it would have otherwise communicated with another Colleague.
/// </summary>
public interface IMediator
{
    void Notify(string message, IColleague sender);
    void RegisterColleague(IColleague colleague);
}

public interface IColleague
{
    IMediator Mediator { get; init; }

    void Send(string message);

    void Receive(string message);
}

public class ConcreteMediator : IMediator
{
    public ConcreteColleagueA? ColleagueA { get; private set; }
    public ConcreteColleagueB? ColleagueB { get; private set; }

    public void RegisterColleague(IColleague colleague)
    {
        if(colleague is ConcreteColleagueA colleagueA)
        {
            ColleagueA = colleagueA;
        }

        if(colleague is ConcreteColleagueB colleagueB)
        {
            ColleagueB = colleagueB;
        }
    }

    public void Notify(string message, IColleague sender)
    {
        if(sender is ConcreteColleagueA)
        {
            Console.WriteLine("Mediator notifiying Colleague B");
            ColleagueB?.Receive(message);
        }

        if(sender is ConcreteColleagueB)
        {
            Console.WriteLine("Mediator notifiying Colleague A");
            ColleagueA?.Receive(message);
        }
    }
}

public class ConcreteColleagueA(IMediator mediator) : IColleague
{
    public IMediator Mediator { get; init; } = mediator;

    public void Send(string message)
    {
        Mediator.Notify(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"Colleague A received: {message}");
    }
}

public class ConcreteColleagueB(IMediator mediator) : IColleague
{
    public IMediator Mediator { get; init; } = mediator;

    public void Send(string message)
    {
        Mediator.Notify(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"Colleague B received: {message}");
    }
}
