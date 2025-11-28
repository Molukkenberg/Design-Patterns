namespace DesignPatterns.Behavioral_Patterns.ChainOfResponsibility;

/// <summary>
/// Purpose: 
/// - The Chain of Responsibility Pattern allows an object to send a command without knowing which object will handle it.
/// 
/// - Avoids coupling the sender of a request to its receiver 
/// by giving more than one object a chance to handle the request.
/// 
/// Applicability:
/// - Requests need to be handled by one of several objects 
/// & the handler isn't known a priori and is instead determined automatically at runtime.
/// - a request without explicitly specifying the target should be sent to one of several potential receivers.
/// - the set of objects that can handle a request should be specified dynamically.
/// 
/// Participants:
/// - Handler: defines an interface for handling requests & optionally implements the successor link.
/// - ConcreteHandler: If the ConcreteHandler can handle the request, it does so; 
///     otherwise, it forwards the request to its successor.
/// - Client: initiates the request to a ConcreteHandler object in the chain.
/// 
/// Interactions:
/// When a client sends a request, it is passed along a chain of handlers, until one of the handlers processes it.
/// 
/// </summary>
public class ChainOfResponsibility
{
}

public interface IHandler
{
    void SetNext(IHandler handler);
    object? Handle(object request);
}

public class ConcreteHandler1 : IHandler
{
    private IHandler? _nextHandler;

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }

    public object? Handle(object request)
    {
        if (request.ToString() == "Request1")
        {
            return $"ConcreteHandler1 handled {request}";
        }
        else if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        else
        {
            return null;
        }
    }
}

public class ConcreteHandler2 : IHandler
{
    private IHandler? _nextHandler;

    public void SetNext(IHandler handler)
    {
        _nextHandler = handler;
    }

    public object? Handle(object request)
    {
        if (request.ToString() == "Request2")
        {
            return $"ConcreteHandler2 handled {request}";
        }
        else if (_nextHandler != null)
        {
            return _nextHandler.Handle(request);
        }
        else
        {
            return null;
        }
    }
}