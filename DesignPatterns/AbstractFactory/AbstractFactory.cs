namespace DesignPatterns.AbstractFactory;

/// <summary>
/// Applicability, Use the abstract factory pattern when:
/// <para>
/// - a system should be independent of how its products are created, composed, and represented.
/// </para>
/// <para>
/// - a system should be configured with one of multiple families of products.
/// </para>
/// <para>
/// - a family of related product objects is designed to be used together, and you need to enforce this constraint.
/// </para>
/// <para>
/// - you want to provide a class library of products, and you want to reveal just their interfaces, not their implementations.
/// </para>
/// <para>
/// Consequences:
/// </para>
/// <para>
/// - Isolation of concrete classes: The abstract factory pattern isolates concrete classes from the client code. The client code only interacts with the abstract interfaces.
/// </para>
/// <para>
/// - Easy to extend: New product families can be added without modifying existing code, adhering to the Open/Closed Principle.
/// </para>
/// <para>
/// - Consistency among products: The pattern ensures that products from the same family are used together.
/// </para>
/// <para>
/// - Support for multiple product families: The abstract factory pattern allows for the creation of multiple families of products.
/// </para>
/// </summary>
public interface IAbstractFactory
{
    public abstract IProductA CreateProductA();
    public abstract IProductB CreateProductB();
}

public interface IProductA
{
}
public interface IProductB
{
}

internal class ProductA1 : IProductA
{
}
internal class ProductA2 : IProductA
{
}

internal class ProductB1 : IProductB
{
}

internal class ProductB2 : IProductB
{
}

internal class ConcreteFactory1 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ProductA1();
    }
    public IProductB CreateProductB()
    {
        return new ProductB1();
    }
}

internal class ConcreteFactory2 : IAbstractFactory
{
    public IProductA CreateProductA()
    {
        return new ProductA2();
    }
    public IProductB CreateProductB()
    {
        return new ProductB2();
    }
}