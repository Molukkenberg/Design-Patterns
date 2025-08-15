namespace DesignPatterns.Structural_Patterns.Bridge;

/// <summary>
/// Implementor hierarchy: color application is the varying implementation dimension.
/// </summary>
public interface IColor
{
    string Apply();
}

public sealed class RedColor : IColor
{
    public string Apply() => "red";
}

public sealed class BlueColor : IColor
{
    public string Apply() => "blue";
}

public sealed class GreenColor : IColor
{
    public string Apply() => "green";
}

/// <summary>
/// Abstraction hierarchy: geometric shapes. Each shape delegates color-specific
/// variation to an IColor implementation injected at construction.
/// </summary>
public abstract class Shape(IColor color)
{
    protected IColor Color { get; } = color;

    /// <summary>
    /// High-level API the client uses (pure function).
    /// </summary>
    public abstract string Draw();

    /// <summary>
    /// Convenience side-effect wrapper.
    /// </summary>
    public void DrawToConsole() => Console.WriteLine(Draw());
}

public sealed class Circle(IColor color) : Shape(color)
{
    public override string Draw() => $"Drawing a {Color.Apply()} circle.";
}

public sealed class Square(IColor color) : Shape(color)
{
    public override string Draw() => $"Drawing a {Color.Apply()} square.";
}

public sealed class Triangle(IColor color) : Shape(color)
{
    public override string Draw() => $"Drawing a {Color.Apply()} triangle.";
}

/// <summary>
/// Demo runner for the Shapes & Colors bridge.
/// </summary>
public static class ShapesAndColorsDemo
{
    public static void Run()
    {
        // Single instances of each shape with different colors
        new Circle(new RedColor()).DrawToConsole();
        new Square(new BlueColor()).DrawToConsole();
        new Triangle(new GreenColor()).DrawToConsole();

        Console.WriteLine("\n-- Orthogonality matrix (Shapes × Colors) --");

        IColor[] colors = [new RedColor(), new BlueColor(), new GreenColor()];

        foreach (IColor color in colors)
        {
            // For each color, create one instance of each shape
            Shape[] shapes =
            [
                new Circle(color),
                new Square(color),
                new Triangle(color)
            ];

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Draw());
            }
        }
    }
}

/// <summary>
/// Entry point wrapper to invoke the Shapes & Colors bridge demo without exposing internal naming externally.
/// </summary>
public static class ShapesAndColorsBridgeExample
{
    public static void Run() => ShapesAndColorsDemo.Run();
}
