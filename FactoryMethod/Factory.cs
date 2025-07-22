namespace DesignPatterns.FactoryMethod;

/// <summary>
/// Applicability, Use the factory pattern when:
/// <para>
/// - a class can't determine the class it should create upfront.
/// </para>
/// <para>
/// - a class expects a specification of created objects by its sub-classes
/// </para>
/// <para>
/// - classes delegate responsiblities to one of multiple helping sub classes 
/// and then determine which subclass is the delegate
/// </para>
/// </summary>
/// <para>
/// Consequences:
/// </para>
/// <para>
/// - Specification options for subclasses: 
/// Creating an object by a factory method is generally more flexible than creating it directly,
/// because the factory subclasses allow you to provide an extended version of an object.
/// </para>
/// <para>
/// - Connects Parallel Class Hierarchies:
/// Parallel class hierarchies arise when a class delegates part of its responsibilities to a helper class.
/// </para>
public interface IFactory
{
    Product CreateProduct();
}

public class Factory : IFactory
{
    public Product CreateProduct()
    {
        return new Product();
    }
}

public interface IProduct
{
}

public class Product : IProduct
{
}