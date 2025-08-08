namespace DesignPatterns.Builder;

public static class BuilderExample
{
    public static void RunWithDirector()
    {
        IBuilder builder = new ConcreteBuilder();
        Director director = new(builder);

        director.Construct();
        Product product = builder.GetResult();

        Console.WriteLine(product);
    }

    public static void RunWithoutDirector()
    {
        IBuilder builder = new ConcreteBuilder();
        builder.BuildPartA();
        builder.BuildPartB();

        Product product = builder.GetResult();

        Console.WriteLine(product);
    }
}