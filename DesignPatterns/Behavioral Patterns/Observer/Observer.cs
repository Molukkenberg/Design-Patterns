namespace DesignPatterns.Behavioral_Patterns.Observer;

/// <summary>
/// Purpose: Define a 1-to-n dependency between objects so that when one object changes state,
///          all its dependents are notified and updated automatically.
///             
/// Also known as: Dependents, Publish-Subscribe
/// 
/// Applicability: Use the Observer pattern when
/// - An abstraction has two aspects, one dependent on the other.
/// - A change to one object requires changing others, 
///   and you don't know how many objects need to be changed.
/// - An object should be able to notify other objects without making assumptions about who these objects are.
/// 
/// Participants:
/// - Subject: Knows its observers. Any number of Observer objects may observe a subject.
/// - Observer: Defines an updating interface for objects that should be notified of changes in a subject.
/// - ConcreteSubject: Stores state of interest to ConcreteObserver objects
///                    and sends a notification to its observers when its state changes.
/// - ConcreteObserver: Implements the Observer updating interface to keep its state consistent with the subject's.
///                     Holds a reference to a ConcreteSubject object.
///                     Saves state that should stay consistent with the subject's.
/// 
/// Variants:
/// - Push Model: The subject sends detailed information to observers in the notification.
/// - Pull Model: The subject sends a simple notification, and observers pull the necessary data from the subject.
/// </summary>
public interface IObserver
{
    void Update();
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Pull model using direct method calls
public class ConcreteSubject : ISubject
{
    public string State { get;  set; } = string.Empty;

    private readonly List<IObserver> _observers = [];

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }
    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}

public class ConcreteObserver : IObserver
{
    public ConcreteSubject Subject { get; private set; }

    public ConcreteObserver(ConcreteSubject subject)
    {
        Subject = subject;
        Subject.Attach(this);
    }
    public void Update()
    {
        // React to the update from the subject
        Console.WriteLine($"Observer: Subject state changed to {Subject.State}");
    }
}

// Push model using events
public interface IPushSubject
{
    void Attach(IPushObserver observer);
    void Detach(IPushObserver observer);
    void Notify();
}

public interface IPushObserver
{
    void Update(EventArgs eventArgs);
}

public class ConcreteEventSubject : IPushSubject
{
    public string State { get; set; } = string.Empty;

    public event EventHandler<SubjectChangedEventArgs>? StateChanged;

    public void Attach(IPushObserver observer)
    {
        StateChanged += (sender, args) => observer.Update(args);
    }
    public void Detach(IPushObserver observer)
    {
        StateChanged -= (sender, args) => observer.Update(args);
    }
    public void Notify()
    {
        StateChanged?.Invoke(this, new SubjectChangedEventArgs(State));
    }
}

public class ConcreteEventObserver : IPushObserver
{
    public ConcreteEventSubject Subject { get; private set; }
    public ConcreteEventObserver(ConcreteEventSubject subject)
    {
        Subject = subject;
        Subject.Attach(this);
    }
    public void Update(EventArgs eventArgs)
    {
        if (eventArgs is SubjectChangedEventArgs args)
        {
            Console.WriteLine($"EventObserver: Subject state changed to {args.NewState}");
        }
    }
}

public sealed class SubjectChangedEventArgs(string newState) : EventArgs
{
    public string NewState { get; } = newState;
}
