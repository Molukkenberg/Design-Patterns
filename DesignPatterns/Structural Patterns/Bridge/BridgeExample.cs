namespace DesignPatterns.Structural_Patterns.Bridge;

/// <summary>
/// Bridge Pattern
///
/// Participants
/// - Abstraction            -> Abstraction (base class the client uses)
/// - RefinedAbstraction     -> RefinedAbstraction (optional extension of Abstraction)
/// - Implementor            -> IImplementation (interface with primitive operation(s))
/// - ConcreteImplementorA   -> ImplementationA
/// - ConcreteImplementorB   -> ImplementationB
///
/// Intent:
/// Decouple an abstraction from its implementation so that both can vary independently.
/// </summary>
public static class BridgeExample
{
    public static void Run()
    {
        Abstraction abstraction;

        abstraction = new Abstraction(new ImplementationA());
        abstraction.Operation();

        abstraction = new RefinedAbstraction(new ImplementationB());
        abstraction.Operation();
    }
}

