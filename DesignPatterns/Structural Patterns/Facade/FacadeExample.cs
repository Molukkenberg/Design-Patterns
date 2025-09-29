namespace DesignPatterns.Structural_Patterns.Facade;
using Microsoft.Extensions.DependencyInjection;

public static class Client
{
    public static void Main()
    {
        ISubsystemA subsystemA = new SubsystemA();
        ISubsystemB subsystemB = new SubsystemB();
        Facade facade = new(subsystemA, subsystemB);
        facade.Operation();
    }
}

/// <summary>
/// Facade example using Dependency Injection
/// </summary>
internal class FacadeExample
{
    public static void Main()
    {
        IServiceCollection services = new ServiceCollection()
            .AddSingleton<ISubsystemA, SubsystemA>()
            .AddSingleton<ISubsystemB, SubsystemB>()
            .AddSingleton<Facade>();

        using ServiceProvider provider = services.BuildServiceProvider();

        Facade facade = provider.GetRequiredService<Facade>();
        facade.Operation();
    }
}

internal class FacadeExampleWithoutDi
{
    public static void Main()
    {
        ISubsystemA subsystemA = new SubsystemA();
        ISubsystemB subsystemB = new SubsystemB();

        Facade facade = new(subsystemA, subsystemB);
        facade.Operation();
    }
}