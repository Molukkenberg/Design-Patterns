namespace DesignPatterns.Prototype;

/// <summary>
/// Consequences:
/// <para>
/// - Product supplementation and removal at runtime
/// </para>
/// <para>
/// - specification of new objects by value variation
/// </para>
/// <para>
/// - specification of new objcets by structural variation
/// </para>
/// <para>
/// - reduced sub class creation
/// </para>
/// <para>
/// - dynamic application configuration by classes
/// </para>
/// </summary>
public interface IPrototype
{
    IProduct Clone();
}

public interface IProduct
{
    string Name { get; set; }
}

public class Product : IProduct, IPrototype
{
    public string Name { get; set; } = default!;

    public IProduct Clone()
    {
        return new Product
        {
            Name = Name,
        };
    }
}
