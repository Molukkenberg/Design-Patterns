namespace DesignPatterns.Behavioral_Patterns.Strategy;

/// <summary>
/// Purpose: 
///     The Strategy pattern defines a family of algorithms, encapsulates each one, 
///     and makes them interchangeable.
/// 
/// Also known as: 
///     Policy
///     
/// Applicability: Apply Strategy when:
///     - Multiple classes differ only in their behavior. 
///       Strategies provide a way to configure a class with one of many behaviors.
///     - Different variants of an algorithm are needed.
///     - An algorithm uses data that clients shouldn't know about.
///     - A class defines many behaviors, and these appear as multiple conditional statements in its operations.
///     
/// Participants:
///     - Strategy: Defines the interface common to all supported algorithms. 
///                 Context uses this interface to call the algorithm defined by a ConcreteStrategy.
///     - ConcreteStrategy: Implements the algorithm using the Strategy interface.
///     - Context: Maintains a reference to a Strategy object and can replace it at runtime.
///
/// Related Patterns:
///     - Flyweight: Can be used to implement a strategy lookup table, 
///                  where strategies are shared and reused to save memory.
///     - State: Similar to Strategy, but State is used to change the behavior of an object 
///              when its internal state changes.
/// 
/// </summary>
public interface IStrategy
{
    void Execute();
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy A");
    }
}

public  class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Strategy B");
    }
}

public class Context(IStrategy Strategy)
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
