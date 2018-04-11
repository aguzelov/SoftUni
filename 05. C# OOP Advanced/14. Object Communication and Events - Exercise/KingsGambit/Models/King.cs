﻿using System.Collections.Generic;

public delegate void KingUnderAttackHandler();

public class King : INamed
{
    public event KingUnderAttackHandler UnderAttack;

    private List<Soldier> soldiers;

    public King(string name)
    {
        this.Name = name;
        this.soldiers = new List<Soldier>();
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<Soldier> Soldiers
    {
        get
        {
            return this.soldiers;
        }
    }

    public void AddSoldier(Soldier soldier)
    {
        this.soldiers.Add(soldier);
        UnderAttack += soldier.KingUnderAttack;
        soldier.SoldierDead += this.OnSoldierDead;
    }

    public void OnAttack()
    {
        System.Console.WriteLine($"King {this.Name} is under attack!");
        this.UnderAttack?.Invoke();
    }

    public void OnSoldierDead(Soldier soldier)
    {
        this.UnderAttack -= soldier.KingUnderAttack;
        this.soldiers.Remove(soldier);
    }
}