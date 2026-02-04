namespace DesignPatterns.Behavioral_Patterns.Observer;

public class ObserverExample
{
    public static void Run()
    {
        ConcreteSubject subject = new();
        ConcreteObserver observer1 = new(subject);
        ConcreteObserver observer2 = new(subject);

        subject.State = "New State 1";
        subject.Notify();
        subject.State = "New State 2";
        subject.Notify();
    }
}
