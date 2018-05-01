namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int repairAmount = 80;

        public Microphone()
        {
        }

        protected override int RepairAmount => repairAmount;
    }
}