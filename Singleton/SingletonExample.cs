namespace DesignPatterns.Singleton;

public class SingletonExample
{
    public static void Run()
    {
        Singleton singletonInstance = Singleton.Instance;
        singletonInstance.Foo("Bar");
    }
}
