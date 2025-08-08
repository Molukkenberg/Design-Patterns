namespace DesignPatterns.Adapter;

/// <summary>
/// Also known as Wrapper Pattern.
/// <para>
/// The Adapter Pattern allows incompatible interfaces to work together.
/// </para>
/// <para>
/// A client calls operations on an adapter and the adapter calls operations on the adaptee.
/// </para>
/// </summary>
public class Adapter
{
}

/// <summary>
/// The Adaptee contains some useful behavior, but its interface is
/// incompatible with the existing client code.
/// </summary>
public class Adaptee : IAdaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Called SpecificRequest");
    }
}

/// <summary>
/// Defines the interface of an existing class that needs adapting.
/// This is the interface the Adapter will wrap.
/// </summary>
public interface IAdaptee
{
    /// <summary>
    /// Represents a method with a specific, non-standard signature that the client cannot call directly.
    /// </summary>
    void SpecificRequest();
}

/// <summary>
/// Defines the domain-specific interface that the Client uses.
/// This is the target interface the Adapter conforms to.
/// </summary>
public interface ITarget
{
    /// <summary>
    /// Represents the standard request that the client makes.
    /// </summary>
    void Request();
}