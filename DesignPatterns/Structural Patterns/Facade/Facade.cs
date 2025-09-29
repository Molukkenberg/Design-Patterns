namespace DesignPatterns.Structural_Patterns.Facade;

/*
 * Purpose:
 * - Provide a unified, interface to a set of interfaces in a subsystem.
 * - Facade defines a simpler API that makes the subsystem easier to use.
 *
 * Applicability:
 * - You want to simplify usage of a complex subsystem.
 * - You want to decouple clients from subsystem classes.
 * - You want to layer your application (facade as the entry to a subsystem).
 */

public interface ISubsystemA
{
    public void Initialize();
    public void DoWork();
    public void Shutdown();
}

public interface ISubsystemB
{
    public void Prepare();
    public void Execute();
    public void Cleanup();
}

public class SubsystemA : ISubsystemA
{
    public void Initialize() => Console.WriteLine("SubsystemA: Initialize");
    public void DoWork() => Console.WriteLine("SubsystemA: DoWork");
    public void Shutdown() => Console.WriteLine("SubsystemA: Shutdown");
}

public class SubsystemB : ISubsystemB
{
    public void Prepare() => Console.WriteLine("SubsystemB: Prepare");
    public void Execute() => Console.WriteLine("SubsystemB: Execute");
    public void Cleanup() => Console.WriteLine("SubsystemB: Cleanup");
}

/// <summary>
/// Facade orchestrates calls to multiple subsystem classes,
/// exposing a minimal, cohesive API to clients.
/// </summary>
public class Facade(ISubsystemA subsystemA, ISubsystemB subSystemB)
{
    /// <summary>
    /// A single high-level operation that coordinates the subsystems.
    /// </summary>
    public void Operation()
    {
        Console.WriteLine("Facade: Starting operation");

        subsystemA.Initialize();
        subSystemB.Prepare();

        subsystemA.DoWork();
        subSystemB.Execute();

        subSystemB.Cleanup();
        subsystemA.Shutdown();

        Console.WriteLine("Facade: Operation complete");
    }
}

