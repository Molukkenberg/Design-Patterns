namespace DesignPatterns.Structural_Patterns.Bridge;

/// <summary>
/// Also known as Handle or Body Pattern.
/// 
/// <item>
/// The bridge pattern decouples an abstraction from its implementation so that the two can vary independently.
/// </item>
/// 
/// <para>
/// Orthogonality: The pattern makes two axes (dimensions) independent (orthogonal):
/// <list type="bullet">
///   <item><b>Abstraction hierarchy</b>: What the client sees (high-level operations).</item>
///   <item><description><b>Implementation hierarchy</b>: 
///     How those operations are carried out (platform / strategy / device / API binding).
///     </description>
///   </item>
/// </list>
/// Because the axes are decoupled, you can freely combine them at runtime producing a conceptual Cartesian product 
/// without creating a concrete subclass for every combination. 
/// Growth cost becomes O(A + I) instead of O(A × I).
/// </para>
/// 
/// <list type="bullet">
///     <item><b>Applicable when:</b> </item>
///     <item>You want to avoid a permanent binding between an abstraction and its implementation.</item>
///     <item>You want to allow the abstraction and its implementation to vary independently.</item>
///     <item>If both the abstraction and the implementation should be extensible by subclassing.</item>
/// </list>
/// </summary>
public class Bridge
{
}

/// <summary>
/// Declares the low-level (primitive) operation(s) the Abstraction will delegate to.
/// Does not need to mirror Abstraction's interface.
/// </summary>
public interface IImplementation
{
    string OperationImplementation();
}

/// <summary>
/// ConcreteImplementor A
/// </summary>
public sealed class ImplementationA : IImplementation
{
    public string OperationImplementation() => "[ImplementationA] platform-specific result.";
}

/// <summary>
/// ConcreteImplementor B
/// </summary>
public sealed class ImplementationB : IImplementation
{
    public string OperationImplementation() => "[ImplementationB] different platform result.";
}

/// <summary>
/// Maintains a reference to an Implementor and defines the high-level interface
/// that relies on delegating work to the Implementor.
/// </summary>
public class Abstraction(IImplementation implementation)
{
    public IImplementation Implementation { get; } = implementation;

    /// <summary>
    /// High-level operation exposed to clients.
    /// Delegates the variant part to the implementation object.
    /// </summary>
    public virtual void Operation()
    {
        string implementationResult = Implementation.OperationImplementation();
        Console.WriteLine($"Abstraction: Delegated -> {implementationResult}");
    }
}

/// <summary>
/// Extends the interface or behavior of Abstraction without changing Implementors.
/// </summary>
public class RefinedAbstraction(IImplementation implementation) : Abstraction(implementation)
{
    public override void Operation()
    {
        string implementationResult = Implementation.OperationImplementation();
        Console.WriteLine($"RefinedAbstraction: Additional logic + ({implementationResult})");
    }
}