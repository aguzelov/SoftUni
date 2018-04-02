using System;
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private IAttackable dummy;

    [SetUp]
    public void TestInit()
    {
        this.axe = new Axe(10, 10);
        this.dummy = new Dummy(10, 10);
    }

    [Test]
    public void TestWeaponLosesDurabilityAfterAttack()
    {
        //Arrange

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Duarability doesn't change after attack.");
    }

    [Test]
    public void TestAttackWithBrokenWeapon()
    {
        //Arrange
        this.axe = new Axe(10, 0);

        //Assert
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}