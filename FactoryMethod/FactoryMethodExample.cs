namespace DesignPatterns.FactoryMethod;

public class FactoryMethodExample
{
    public static void Run()
    {
        IFactory factory = new Factory();
        IProduct product = factory.CreateProduct();

        Console.WriteLine(product);
    }
}