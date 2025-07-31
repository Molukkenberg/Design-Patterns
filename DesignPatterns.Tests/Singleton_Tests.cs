namespace DesignPatterns.Tests;

using DesignPatterns.Singleton;

[TestClass]
public sealed class Singleton_Tests
{
    [TestMethod]
    public void AreInstancesTheSame()
    {
        Singleton instance = Singleton.Instance;
        Singleton anotherInstance = Singleton.Instance;

        Assert.IsNotNull(instance);
        Assert.AreSame(instance, anotherInstance, "Instances should be the same.");
    }
}
