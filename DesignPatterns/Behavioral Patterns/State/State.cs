namespace DesignPatterns.Behavioral_Patterns.State;

/// <summary>
/// Purpose: 
///     Allow an object to alter its behavior when its internal state changes.
///     
/// Applicability: 
///     Use the State pattern when
///     -  An object's behavior depends on its state, 
///        and it must change its behavior at runtime depending on that state.
///     -  Operations have large, multipart conditional statements that depend on the object's state.
///     
/// Participants:
///     -  Context: Defines the interface of interest to clients.
///                 Keeps an instance of a ConcreteState subclass that defines the current state.
///     -  State: 
///                 Defines an interface or abstract class that encapsulates 
///                 the behavior associated with a particular state of the Context.
///     -  Concrete States: 
///                 Classes that implement the state interface and define specific behaviors for each state.
///                 
/// Interactions:
///     - The Context delegates state-specific behavior to the current State object.
///     - Context can pass itself as an argument to the State object, 
///         allowing the State to change the Context's state.
///     - Context is the most important interface for clients. 
///         Clients configure a Context with State objects and then interact only with the Context.
///     - Which State is the current one can be determined by Context or ConcreteState classes.
/// </summary>
public interface IState
{
    void Handle();

    // Optional:
    void OnEnter() { }
    void OnExit() { }
}

/// <summary>
/// Context could be named StateMachine
/// Client interacts with the Context, which delegates state-specific behavior to the current State object.
/// </summary>
public interface IContext
{
    void SetState(IState newState);
    void Request();
}

public class Context : IContext
{
    private IState _state;
    public Context(IState state) 
    {
        _state = state;
        _state.OnEnter();
    }
    public void SetState(IState newState)
    {
        _state.OnExit();
        _state = newState;
        _state.OnEnter();
    }
    public void Request()
    {
        _state.Handle();
    }
}

public class ConcreteStateA : IState
{
    public void Handle()
    {
        Console.WriteLine("Handling request in ConcreteStateA");
    }
    public void OnEnter()
    {
        Console.WriteLine("Entering ConcreteStateA");
    }
    public void OnExit()
    {
        Console.WriteLine("Exiting ConcreteStateA");
    }
}

public class ConcreteStateB : IState
{
    public void Handle()
    {
        Console.WriteLine("Handling request in ConcreteStateB");
    }
    public void OnEnter()
    {
        Console.WriteLine("Entering ConcreteStateB");
    }
    public void OnExit()
    {
        Console.WriteLine("Exiting ConcreteStateB");
    }
}
