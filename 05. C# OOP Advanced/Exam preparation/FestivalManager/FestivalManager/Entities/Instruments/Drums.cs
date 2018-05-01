namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int repairAmount = 20;

        public Drums()
        {
        }

        protected override int RepairAmount => repairAmount;
    }
}