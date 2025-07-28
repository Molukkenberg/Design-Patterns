namespace DesignPatterns.Prototype;

public class PrototypeExample
{
    static void Run()
    {
        Product product = new()
        {
            Name = "Original Product"
        };

        IProduct clonedProduct = product.Clone();
        clonedProduct.Name = "Cloned Product";

        Console.WriteLine($"Original Product Name: {product.Name}");
        Console.WriteLine($"Cloned Product Name: {clonedProduct.Name}");
    }
}
