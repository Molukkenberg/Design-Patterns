namespace DesignPatterns.Behavioral_Patterns.Strategy;

public class WalkingStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Walking...");
    }
}

public class BikeStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Riding a bike...");
    }
}

public class CarStrategy : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Driving a car...");
    }
}

public class NavigatorContext(IStrategy Strategy)
{
    public void SetStrategy(IStrategy strategy)
    {
        Strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        Strategy?.Execute();
    }
}

public class StrategyExample
{
    public static void Example()
    {
        Context context = new(new ConcreteStrategyA());

        context.ExecuteStrategy(); // Output: Executing Strategy A
        context.SetStrategy(new ConcreteStrategyB());
        context.ExecuteStrategy(); // Output: Executing Strategy B
    }

    public static void ExampleWithNavigator()
    {
        NavigatorContext navigator = new(new WalkingStrategy());
        navigator.ExecuteStrategy(); // Output: Walking...
        navigator.SetStrategy(new BikeStrategy());
        navigator.ExecuteStrategy(); // Output: Riding a bike...
        navigator.SetStrategy(new CarStrategy());
        navigator.ExecuteStrategy(); // Output: Driving a car...
    }
}