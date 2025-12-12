namespace DesignPatterns.Behavioral_Patterns.Iterator;

public class IteratorExample()
{
    public static void Run()
    {
        ConcreteAggregate<string> aggregate = new();

        aggregate.AddItem("Item 1");
        aggregate.AddItem("Item 2");
        aggregate.AddItem("Item 3");

        var iterator = aggregate.CreateIterator();
        Console.WriteLine("Iterating forward:");

        for (var item = iterator.First(); !iterator.IsDone(); item = iterator.Next())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Iterating backward:");
        for (var item = iterator.Last(); !iterator.IsDone(); item = iterator.Previous())
        {
            Console.WriteLine(item);
        }
    }
}
