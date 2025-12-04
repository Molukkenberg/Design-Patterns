namespace DesignPatterns.Behavioral_Patterns.Command;

/// <summary>
/// Purpose:
/// - Encapsulate a request as an object, 
/// thereby allowing for parameterization of clients with queues, requests, and operations.
/// as well as support for undoable operations.
/// 
/// <para/>
/// 
/// Also known as:
/// - Action Object
/// - Transaction
/// 
/// <para/>
/// 
/// Applicability:
/// Use the Command pattern when
/// - You want to parametrize objects with operations.
/// - You want to specify, queue, or execute requests at different times.
/// - You want to support undo-able operations.
/// - You want to protocolize changes. => achieved by extending the command interface to load and save
/// - You want to structure a system around high-level operations built on primitive operations.
/// 
/// <para/>
/// 
/// Participants:
/// - Command:  declares an interface for executing a command. 
/// - ConcreteCommand: defines a binding between a Receiver object and an action, 
///     implements Execute by invoking the corresponding operation(s) on Receiver. 
/// - Client:   creates a ConcreteCommand object and sets its receiver. 
/// - Invoker:  Asks the command object to execute the request. 
/// - Receiver: Can execute the operations associated with the request. 
/// </summary>
public interface ICommand
{
    void Execute();

    // Optional
    void Undo();
    bool CanExecute();
}

/// <summary>
/// Used on the receiver side, 
/// e.g. business logic objects, application, editor, etc.
/// </summary>
public interface IReceiver
{
    void Action();

    // Optional
    void UndoAction();
}

/// <summary>
/// Invokes the command.
/// <para/>
/// Used on Buttons, MenuItems, etc.
/// </summary>
public interface IInvoker
{
    void InvokeCommand();
    void SetCommand(ICommand command);
}

public class ConcreteCommand(IReceiver receiver) : ICommand
{
    public void Execute() => receiver.Action();
    public void Undo() => receiver.UndoAction();
    public bool CanExecute() => true;
}

public class Receiver : IReceiver
{
    public void Action() => Console.WriteLine("Receiver action executed!");
    public void UndoAction() => Console.WriteLine("Receiver action undone!");
}