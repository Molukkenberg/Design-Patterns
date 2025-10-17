namespace DesignPatterns.Structural_Patterns.Flyweight;

internal class FlyweightExample
{
    static void Main()
    {
        FlyweightFactory factory = new();

        string[] intrinsicValues = ["TypeA", "TypeB", "TypeA", "TypeC", "TypeB", "TypeA"];

        foreach (string intrinsicValue in intrinsicValues)
        {
            Flyweight flyweight = factory.GetFlyweight(intrinsicValue);
            flyweight.Operation($"Context for {intrinsicValue}");
        }
    }

}

