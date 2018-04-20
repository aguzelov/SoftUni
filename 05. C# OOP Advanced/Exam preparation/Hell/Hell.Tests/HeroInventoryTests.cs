using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory inventory;

    [SetUp]
    public void TestInit()
    {
        this.inventory = new HeroInventory();
    }

    [Test]
    public void TestConstructInventory()
    {
        //Arrange

        //Act

        //Assert
        Assert.AreEqual(0, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(0, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(0, this.inventory.TotalDamageBonus);
        Assert.AreEqual(0, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(0, this.inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void TestAddCommonItem()
    {
        //Arrange
        string itemName = "Staff";
        IItem item = new CommonItem(itemName, 0, 10, 50, 100, 1000);

        //Act
        this.inventory.AddCommonItem(item);

        //Assert
        Assert.AreEqual(0, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(10, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(50, this.inventory.TotalIntelligenceBonus);
        Assert.AreEqual(100, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(1000, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void TestItemsCountAfterAddCommonItem()
    {
        string itemName = "Staff";
        IItem item = new CommonItem(itemName, 0, 10, 50, 100, 100);

        //Act
        this.inventory.AddCommonItem(item);
        FieldInfo fieldInfo = this.inventory
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.CustomAttributes.Count(a => a.AttributeType == typeof(ItemAttribute)) > 0);

        var items = (Dictionary<string, IItem>)fieldInfo.GetValue(this.inventory);
        int itemsCount = items.Count;

        //Assert
        Assert.AreEqual(1, itemsCount);
    }

    [Test]
    public void TestCompareAddeditemAndActualItem()
    {
        //Arrange
        string itemName = "Staff";
        IItem item = new CommonItem(itemName, 0, 10, 50, 100, 100);

        //Act
        this.inventory.AddCommonItem(item);
        FieldInfo fieldInfo = this.inventory
            .GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.CustomAttributes.Count(a => a.AttributeType == typeof(ItemAttribute)) > 0);

        var items = (Dictionary<string, IItem>)fieldInfo.GetValue(this.inventory);
        IItem actualItem = items[itemName];

        //Assert
        Assert.AreSame(item, actualItem);
    }

    [Test]
    public void TestAddCommonItemWithNull()
    {
        //Arrange

        //Act

        //Assert
        Assert.Throws<NullReferenceException>(() => this.inventory.AddCommonItem(null));
    }

    [Test]
    public void TestAddingNewRecipeItemInInventory()
    {
        //Arrange
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        CommonItem item2 = new CommonItem("item2", 1, 2, 3, 4, 5);
        IRecipe recipe = new RecipeItem("recipe", 10, 20, 30, 40, 50, new List<string>() { item.Name, item2.Name });

        //Act
        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item2);
        this.inventory.AddRecipeItem(recipe);

        Type inventoryType = typeof(HeroInventory);

        var fieldItemColl = inventoryType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collectionItem = (Dictionary<string, IItem>)fieldItemColl.GetValue(this.inventory);

        var fieldRecipeColl
            = inventoryType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Skip(1)
            .FirstOrDefault();
        var collectionRecipe = (Dictionary<string, IRecipe>)fieldRecipeColl.GetValue(this.inventory);

        //Assert
        Assert.AreEqual(10, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(20, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(30, this.inventory.TotalIntelligenceBonus);
        Assert.AreEqual(40, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(50, this.inventory.TotalDamageBonus);
        Assert.AreEqual(1, collectionItem.Count);
        Assert.AreEqual(1, collectionRecipe.Count);
    }

    [Test]
    public void AddNewItemToCompleteRecipe()
    {
        //Arrange
        var item = new CommonItem("item", 1, 2, 3, 4, 5);
        var item2 = new CommonItem("item2", 1, 2, 3, 4, 5);
        IRecipe recipe = new RecipeItem("recipe", 10, 20, 30, 40, 50, new List<string>() { "item", "item2" });

        //Act
        this.inventory.AddCommonItem(item);
        this.inventory.AddRecipeItem(recipe);
        this.inventory.AddCommonItem(item2);

        //Assert
        Assert.AreEqual(50, this.inventory.TotalDamageBonus);
    }
}