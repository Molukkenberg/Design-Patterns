namespace DesignPatterns.Behavioral_Patterns.Memento;

public class MementoExample
{
    public static void Run()
    {
        Originator originator = new();
        Caretaker caretaker = new();

        originator.State = "State1";
        caretaker.SaveState(originator);
        originator.State = "State2";

        caretaker.RestoreState(originator); // Restores to State1
    }

    public static void RunWithHistory()
    {
        Originator originator = new();
        CaretakerWithHistory caretaker = new();

        originator.State = "State1";
        caretaker.SaveState(originator);

        originator.State = "State2";
        caretaker.SaveState(originator);

        originator.State = "State3";
        caretaker.RestoreState(originator); // Restores to State2
        caretaker.RestoreState(originator); // Restores to State1
    }
}