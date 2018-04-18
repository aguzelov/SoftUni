public interface IWareHouse
{
    void AddAmmunition(string ammunitionName, int quantity);

    void EquipArmy(IArmy army);

    bool TryEquipSoldier(ISoldier soldier);
}