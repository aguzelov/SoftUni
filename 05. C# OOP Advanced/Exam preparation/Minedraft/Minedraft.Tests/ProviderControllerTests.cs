using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ProviderControllerTests
{
    private IProviderController providerController;
    private IEnergyRepository energyRepository;

    [SetUp]
    public void TestInit()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void RegisterWithCorrectInput()
    {
        // Act
        this.providerController.Register(new List<string> { "Pressure", "40", "100" });
        var providersCount = this.providerController.Entities.Count;

        // Assert

        Assert.AreEqual(1, providersCount, "Count of registered providers is not corect!");
    }

    [Test]
    public void ProduceWithValidProviders()
    {
        // Arrange
        this.providerController.Register(new List<string> { "Pressure", "40", "100" });
        this.providerController.Register(new List<string> { "Solar", "80", "100" });

        // Act
        this.providerController.Produce();
        var energyProduced = this.providerController.TotalEnergyProduced;

        // Assert
        Assert.AreEqual(300, energyProduced, "Total Energy Produced is not corect!");
    }

    [Test]
    public void ProduceRemoveBrokenProviders()
    {
        this.providerController.Register(new List<string> { "Pressure", "10", "100" });
        this.providerController.Register(new List<string> { "Solar", "10", "100" });
        this.providerController.Register(new List<string> { "Standart", "10", "100" });

        for (int i = 0; i <= 10; i++)
        {
            this.providerController.Produce();
        }

        int expectedCount = 1;
        int actualCount = this.providerController.Entities.Count;

        Assert.AreEqual(expectedCount, actualCount, "Prividers count is not correct!");
    }
}