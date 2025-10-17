namespace DesignPatterns.Structural_Patterns.Flyweight;

/* Terminology:
 * - Intrinsic State: Invariant, shareable data stored inside the flyweight instance.
 * - Extrinsic State: Context-specific, varying data supplied from the outside for each operation.
 * - Flyweight: An object that represents (and encapsulates) intrinsic state only.
 * - Shared Concrete Flyweight: cached & reused, minimizing object count.
 * - Unshared Concrete Flyweight: unique instances (e.g., composites) not suitable for pooling.
 *
 * Purpose: 
 * Common usage of fine-grained objects to support large numbers of similar objects efficiently.
 * 
 * Applicability:
 * 1. When an application uses a large number of objects.
 * 2. When storage costs are high because of the sheer quantity of objects.
 * 3. When most object state can be made extrinsic.
 * 4. Many groups of objects can be replaced by relatively few shared objects once extrinsic state is removed.
 * 5. The application doesn't depend on object identity.
 * 
 */

public interface IFlyweight
{
    void Operation(string extrinsicState);
}

public class Flyweight(string intrinsicState) : IFlyweight
{
    /// <summary>
    /// IntrinsicState = Key identifying the flyweight
    /// </summary>
    private string IntrinsicState { get; init; } = intrinsicState;
    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"Intrinsic State: {IntrinsicState}, Extrinsic State: {extrinsicState}");
    }
}

public class UnsharedConcreteFlyweight(string allState) : IFlyweight
{
    private string AllState { get; init; } = allState;
    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"All State: {AllState}, Extrinsic State: {extrinsicState}");
    }
}

public class FlyweightFactory
{
    /// <summary>
    /// Cache of flyweight objects
    /// </summary>
    private Dictionary<string, Flyweight> Flyweights { get; set; } = [];

    public Flyweight GetFlyweight(string key)
    {
        if (!Flyweights.TryGetValue(key, out Flyweight? value))
        {
            value = new Flyweight(key);
            Flyweights[key] = value;
        }

        return value;
    }
}