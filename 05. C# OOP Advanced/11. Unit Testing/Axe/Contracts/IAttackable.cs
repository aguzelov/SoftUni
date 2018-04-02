public interface IAttackable
{
    void TakeAttack(int attackPoints);

    int GiveExperience();

    bool IsDead();
}