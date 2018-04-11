﻿public delegate void SoldierDiedHandler(Soldier soldier);

public abstract class Soldier : INamed
{
    public event SoldierDiedHandler SoldierDead;

    public Soldier(string name, int health)
    {
        this.Name = name;
        this.Health = health;
    }

    public int Health { get; private set; }

    public string Name { get; private set; }

    public void TakeAttack()
    {
        this.Health -= 1;

        if (this.Health == 0)
        {
            SoldierDead?.Invoke(this);
        }
    }

    public abstract void KingUnderAttack();
}