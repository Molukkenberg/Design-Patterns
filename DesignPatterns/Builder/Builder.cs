namespace DesignPatterns.Builder;

/// <summary>
/// Applicability, Use the builder pattern when:
/// <para>
/// - the algorithm for creating a complex object should be independent of the parts and their composition.
/// </para>
/// <para>
/// the construction process should allow different representations for the object that is constructed.
/// </para>
/// </summary>
public interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    Product GetResult();
}

public class ConcreteBuilder : IBuilder
{
    private Product _product = new();

    public void BuildPartA()
    {
        _product.Add("PartA");
    }

    public void BuildPartB()
    {
        _product.Add("PartB");
    }

    public Product GetResult()
    {
        Product result = _product;
        _product = new Product();
        return result;
    }
}

public class Product
{
    private readonly List<string> _parts = [];

    public void Add(string part)
    {
        _parts.Add(part);
    }

    public override string ToString()
    {
        return $"Product parts: {string.Join(", ", _parts)}";
    }
}

public class Director(IBuilder builder)
{
    public void Construct()
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}