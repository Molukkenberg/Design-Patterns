namespace DesignPatterns.Behavioral_Patterns.Mediator;

public static class MediatorExample
{
    public static void Run()
    {
        ConcreteMediator mediator = new();
        ConcreteColleagueA colleagueA = new(mediator);
        ConcreteColleagueB colleagueB = new(mediator);

        mediator.RegisterColleague(colleagueA);
        mediator.RegisterColleague(colleagueB);

        colleagueA.Send("Hello from A");
        colleagueB.Send("Hello from B");
    }
}