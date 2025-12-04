namespace DesignPatterns.Behavioral_Patterns.Command;

public class Editor : IEditorReceiver
{
    public void Copy()
    {
    }

    public void Cut()
    {
    }

    public void Paste()
    {
    }
}

public interface IEditorReceiver
{
    void Copy();
    void Paste();
    void Cut();
}

public class Button(ICommand Command, CommandHistory CommandHistory) : IInvoker
{
    public void InvokeCommand()
    {
        Console.WriteLine("Button clicked!");

        if (!Command.CanExecute())
        {
            return;
        }

        Command.Execute();
        CommandHistory.Push(Command);
    }

    public void SetCommand(ICommand command)
    {
        Command = command;
    }
}

public class ShortCut(ICommand Command, CommandHistory CommandHistory) : IInvoker
{
    public void InvokeCommand()
    {
        Console.WriteLine("Shortcut activated!");

        if (!Command.CanExecute())
        {
            return;
        }

        Command.Execute();
        CommandHistory.Push(Command);
    }
    public void SetCommand(ICommand command)
    {
        Command = command;
    }
}

public class CopyCommand(IEditorReceiver editor) : ICommand
{
    public void Execute()
    {
        editor.Copy();
    }
    public void Undo()
    {
        // Not implemented
    }
    public bool CanExecute()
    {
        return true;
    }
}

public class PasteCommand(IEditorReceiver editor) : ICommand
{
    public void Execute()
    {
        editor.Paste();
    }
    public void Undo()
    {
        // Not implemented
    }
    public bool CanExecute()
    {
        return true;
    }
}

public class CutCommand(IEditorReceiver editor) : ICommand
{
    public void Execute()
    {
        editor.Cut();
    }
    public void Undo()
    {
        // Not implemented
    }
    public bool CanExecute()
    {
        return true;
    }
}

public class CommandHistory()
{
    private readonly Stack<ICommand> _history = new();
    private readonly Stack<ICommand> _undoneCommands = new();

    public void Push(ICommand command)
    {
        _history.Push(command);
        _undoneCommands.Clear();
    }

    public void Undo()
    {
        if (_history.Count <= 0)
        {
            return;
        }
        ICommand command = _history.Pop();
        command.Undo();
        _undoneCommands.Push(command);
    }

    public void Redo()
    {
        if(_undoneCommands.Count <= 0)
        {
            return;
        }

        ICommand command = _undoneCommands.Pop();
        command.Execute();

        _history.Push(command);
    }
}

public class CommandExample2()
{
    static void Main()
    {
        Editor editor = new();
        CommandHistory commandHistory = new();

        ICommand copyCommand = new CopyCommand(editor);
        ICommand pasteCommand = new PasteCommand(editor);
        ICommand cutCommand = new CutCommand(editor);

        Button copyButton = new(copyCommand, commandHistory);
        Button pasteButton = new(pasteCommand, commandHistory);
        Button cutButton = new(cutCommand, commandHistory);

        ShortCut copyShortCut = new(copyCommand, commandHistory);
        ShortCut pasteShortCut = new(pasteCommand, commandHistory);
        ShortCut cutShortCut = new(cutCommand, commandHistory);

        copyButton.InvokeCommand();
        pasteButton.InvokeCommand();

        Console.WriteLine("Undo last action:");
        commandHistory.Undo();

        Console.WriteLine("Redo last action:");
        commandHistory.Redo();
    }
}