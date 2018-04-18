using System;
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private Dictionary<string, int> ammunitionQuantity;

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.ammunitionQuantity = new Dictionary<string, int>();
    }

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.ammunitionQuantity = new Dictionary<string, int>();
    }

    public void AddAmmunition(string ammunitionName, int quantity)
    {
        if (!this.ammunitionQuantity.ContainsKey(ammunitionName))
        {
            this.ammunitionQuantity.Add(ammunitionName, 0);
        }
        this.ammunitionQuantity[ammunitionName] += quantity;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var wepoans = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();
        bool isFullEquip = true;
        foreach (var weaponName in wepoans)
        {
            if (ammunitionQuantity.ContainsKey(weaponName) && ammunitionQuantity[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.ammunitionQuantity[weaponName]--;
            }
            else
            {
                isFullEquip = false;
            }
        }

        return isFullEquip;
    }
}