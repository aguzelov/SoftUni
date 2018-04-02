using NUnit.Framework;
using System;

public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.dummy = new Dummy(10, 10);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        //Arrange
        var expectedHp = 5;

        //Act
        dummy.TakeAttack(5);

        //Assert
        Assert.AreEqual(expectedHp, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowExceptionIfAttacked()
    {
        //Arrange

        //Act
        dummy.TakeAttack(10);

        //Assert
        Assert.That(() => dummy.TakeAttack(1),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        //Arrange
        var expextedXP = 10;

        //Act
        dummy.TakeAttack(11);

        //Assert
        Assert.AreEqual(expextedXP, dummy.GiveExperience());
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        //Arrange

        //Assert
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}