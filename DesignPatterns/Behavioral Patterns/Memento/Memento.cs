namespace DesignPatterns.Behavioral_Patterns.Memento;

/// <summary>
/// Purpose:        Store internal state of an object without violating encapsulation,
///                 so it can be restored later.
///          
/// Also known as:  Token
/// 
/// Applicability:
///   - When you need to restore an object to a previous state (e.g., undo/redo operations).
///   - When direct access to the object's state would violate encapsulation.
///   
/// Participants:
///   - Memento: Stores the internal state of the Originator object.
///   - Originator: Creates a memento containing a snapshot of its current state and uses the memento to restore its state.
///   - Caretaker: Responsible for keeping the memento. It never operates on or examines the contents of a memento.
/// </summary>
public class Memento
{
    public required string State { get; set; }

    // Original Pattern parts, commented out to modernize with auto-properties

    //public string GetState()
    //{
    //    return State;
    //}

    //public void SetState(string state)
    //{
    //    State = state;
    //}
}

public class Originator
{
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Also known as: Restore / SetState
    /// </summary>
    /// <param name="memento"></param>
    public void SetMemento(Memento memento)
    {
        State = memento.State;
    }
    
    public Memento CreateMemento()
    {
        return new Memento { State = State };
    }
}

public class Caretaker
{
    private Memento? memento;

    public void SaveState(Originator originator)
    {
        memento = originator.CreateMemento();
    }

    public void RestoreState(Originator originator)
    {
        if (memento != null)
        {
            originator.SetMemento(memento);
        }
    }
}

public class CaretakerWithHistory
{
    private readonly Stack<Memento> _mementos = [];

    public void SaveState(Originator originator)
    {
        _mementos.Push(originator.CreateMemento());
    }

    public void RestoreState(Originator originator)
    {
        if (_mementos.Count > 0)
        {
            var memento = _mementos.Pop();
            originator.SetMemento(memento);
        }
    }
}
