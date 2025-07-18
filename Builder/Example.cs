namespace DesignPatterns.Builder;

public static class Example
{
    public static void RunWithBuilder()
    {
        ConcreteBuilder builder = new();
        Director director = new(builder);

        director.Construct();
        Product product = builder.GetResult();

        Console.WriteLine(product);
    }

    public static void RunWithoutDirector()
    {
        ConcreteBuilder builder = new();
        builder.BuildPartA();
        builder.BuildPartB();

        Product product = builder.GetResult();

        Console.WriteLine(product);
    }
}