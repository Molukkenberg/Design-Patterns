namespace DesignPatterns.Behavioral_Patterns.Command;

/// <summary>
/// Command Example // Client code
/// </summary>
public static class CommandExample
{
    public static void Run()
    {
        Receiver receiver = new();

        ICommand command = new ConcreteCommand(receiver);

        ExampleButton button = new(command);
        MenuItem menuItem = new(command);
    }
}

public class ExampleButton(ICommand Command) : IInvoker
{
    public void InvokeCommand()
    {
        Console.WriteLine("Button clicked!");

        if (!Command.CanExecute())
        {
            return;
        }

        Command.Execute();
    }

    public void SetCommand(ICommand command)
    {
        Command = command;
    }
}

public class MenuItem(ICommand Command) : IInvoker
{
    public void InvokeCommand()
    {
        Console.WriteLine("Menu item selected!");

        if (!Command.CanExecute())
        {
            return;
        }

        Command.Execute();
    }

    public void SetCommand(ICommand command)
    {
        Command = command;
    }
}