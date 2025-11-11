namespace DesignPatterns.Structural_Patterns.Proxy;

/*
 * Purpose:
 *
 * - To provide a pre surrogate or placeholder for another object to control access or
 *   delay instantiation.
 *
 * Also Known As
 * - Surrogate
 *
 * Applicability:
 * 1. Virtual proxy: creates expensive objects on demand.
 * 2. Remote proxy: provides a local representative for an object in a different address space.
 * 3. Protection proxy: controls access to the original object. Useful when objects should have different access rights.
 * 
*/

public interface ISubject
{
    void Request();
}

public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling Request.");
    }
}

public class SubjectProxy(ISubject? realSubject = null) : ISubject
{
    public void Request()
    {
        // Protection Proxy: Check access before forwarding the request

        if (CheckAccess() == false)
        {
            return;
        }

        // Virtual Proxy: Lazy initialization of the RealSubject

        realSubject ??= new RealSubject();

        Console.WriteLine("Proxy: Logging request before forwarding to RealSubject.");

        // Forward the request to the real subject
        realSubject.Request();
    }

    private static bool CheckAccess()
    {
        // Simulate access check
        return true;
    }
}