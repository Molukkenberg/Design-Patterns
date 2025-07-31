namespace DesignPatterns.Singleton;

public class Singleton
{
    private Singleton() { }
    public static Singleton Instance { get; } = new();

    private string? _name;
    public void Foo(string name)
    {
        _name = name;
    }
}
