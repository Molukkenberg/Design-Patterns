namespace DesignPatterns.AbstractFactory;

public class AbstractFactoryExample
{
    public static void RunWithProductFamilyOne()
    {
        bool useProductFamilyOne = true;

        IAbstractFactory factory = useProductFamilyOne
            ? new ConcreteFactory1()
            : new ConcreteFactory2();

        CreateProducts(factory);
    }

    public static void RunWithProductFamilyTwo()
    {
        bool useProductFamilyOne = false;

        IAbstractFactory factory = useProductFamilyOne
            ? new ConcreteFactory1()
            : new ConcreteFactory2();

        CreateProducts(factory);
    }

    private static void CreateProducts(IAbstractFactory factory)
    {
        IProductA productA = factory.CreateProductA();
        IProductB productB = factory.CreateProductB();

        Console.WriteLine($"Created {productA.GetType()}" +
            $" and {productB.GetType()} using {factory.GetType()}.");
    }
}
