namespace DesignPatterns.Behavioral_Patterns.State;

public class StateExample
{
    public static void Main()
    {
        IState stateA = new ConcreteStateA();
        IState stateB = new ConcreteStateB();
        IContext context = new Context(stateA);

        context.Request(); 
        context.SetState(stateB);
        context.Request(); 
    }
}