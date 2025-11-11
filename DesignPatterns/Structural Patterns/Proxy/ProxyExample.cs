namespace DesignPatterns.Structural_Patterns.Proxy;

internal class ProxyExample
{
    public static void Run()
    {
        Console.WriteLine("=== Direct call (no proxy) ===");
        RealSubject realSubject = new();
        realSubject.Request();

        Console.WriteLine();
        Console.WriteLine("=== Proxy call (first - triggers lazy creation) ===");
        SubjectProxy proxy = new();
        proxy.Request();

        Console.WriteLine();
        Console.WriteLine("=== Proxy call (second - reuses existing RealSubject) ===");
        proxy.Request();

        Console.WriteLine();
        Console.WriteLine("=== Proxy call (with existing RealSubject) ===");
        SubjectProxy anotherProxy = new(realSubject);
        anotherProxy.Request();
    }
}
