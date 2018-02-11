using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
    class Jarvis
    {
        static Robot jarvis = null;

        static bool TakeComponent()
        {
            string[] components = Console.ReadLine()
                                        .Split(' ')
                                        .Where(p => !string.IsNullOrWhiteSpace(p))
                                        .ToArray();

            if (components[0] == "Assemble!")
            {
                jarvis.Assemble();
                return false;
            }

            jarvis.AddComponent(components);

            return true;
        }


        static void Main(string[] args)
        {
            long energyCapacity = long.Parse(Console.ReadLine());

            jarvis = new Robot(energyCapacity);

            while (TakeComponent()) { }
        }
    }

    class Robot
    {
        private long maxEnergyCapacity;
        private List<Head> head = new List<Head>();
        private List<Torso> torso = new List<Torso>();
        private List<Arm> arms = new List<Arm>();
        private List<Leg> legs = new List<Leg>();

        public Robot(long maxEnergyCapacity)
        {
            this.maxEnergyCapacity = maxEnergyCapacity;
        }

        public void AddComponent(string[] component)
        {
            //{typeOfComponent} {energyConsumption} {property1} {property2}
            string type = component[0];

            // remove remove first element from compunent[]
            List<string> temp = component.ToList();
            temp.RemoveAt(0);
            component = temp.ToArray();

            switch (type)
            {
                case "Head": AddHead(component); break;
                case "Torso": AddTorso(component); break;
                case "Arm": AddArm(component); break;
                case "Leg": AddLeg(component); break;
                default:
                    break;
            }
        }

        private void AddHead(string[] headInfo)
        {
            long energy = long.Parse(headInfo[0]);
            int iq = int.Parse(headInfo[1]);
            string skin = headInfo[2];

            head.Add(new Head(energy, iq, skin));
        }

        private void AddTorso(string[] torsoInfo)
        {
            long energy = long.Parse(torsoInfo[0]);
            double processorSie = double.Parse(torsoInfo[1]);
            string housingMaterial = torsoInfo[2];

            torso.Add(new Torso(energy, processorSie, housingMaterial));
        }

        private void AddArm(string[] armInfo)
        {
            long energy = long.Parse(armInfo[0]);
            int reachDistance = int.Parse(armInfo[1]);
            int fingers = int.Parse(armInfo[2]);

            arms.Add(new Arm(energy, reachDistance, fingers));
        }

        private void AddLeg(string[] legInfo)
        {
            long energy = long.Parse(legInfo[0]);
            int strength = int.Parse(legInfo[1]);
            int speed = int.Parse(legInfo[2]);

            legs.Add(new Leg(energy, strength, speed));
        }

        public void Assemble()
        {
            if (!HasEnoughPart())
            {
                Console.WriteLine("We need more parts!");
            }
            else if (!HasEnoughEnergy())
            {
                Console.WriteLine("We need more power!");
            }
            else
            {
                Console.WriteLine("Jarvis:");

                Head currentHead = head.OrderBy(x => x.EnergyConsumption).Take(1).First();
                Console.WriteLine(currentHead.ToString());

                Torso currentTorso = torso.OrderBy(x => x.EnergyConsumption).Take(1).First();
                Console.WriteLine(currentTorso.ToString());

                Arm[] armsArray = arms.OrderBy(x => x.EnergyConsumption).Take(2).ToArray();
                Console.WriteLine(armsArray[0].ToString());
                Console.WriteLine(armsArray[1].ToString());


                Leg[] legArray = legs.OrderBy(x => x.EnergyConsumption).Take(2).ToArray();
                Console.WriteLine(legArray[0].ToString());
                Console.WriteLine(legArray[1].ToString());
            }
        }

        private bool HasEnoughPart()
        {
            if (head.Count == 0 || torso.Count == 0 ||
                arms.Count < 2 || legs.Count < 2)
            {
                return false;
            }
            return true;
        }

        private bool HasEnoughEnergy()
        {
            long armsEnergy = arms.OrderBy(x => x.EnergyConsumption).First().EnergyConsumption +
                              arms.OrderBy(x => x.EnergyConsumption).Skip(1).Take(1).First().EnergyConsumption;

            long legsEnergy = legs.OrderBy(x => x.EnergyConsumption).First().EnergyConsumption +
                              legs.OrderBy(x => x.EnergyConsumption).Skip(1).Take(1).First().EnergyConsumption;

            long headEnergy = head.OrderBy(x => x.EnergyConsumption).First().EnergyConsumption;

            long torsoEnergy = torso.OrderBy(x => x.EnergyConsumption).First().EnergyConsumption;

            if (maxEnergyCapacity >= (armsEnergy + legsEnergy + torsoEnergy + headEnergy))
            {
                return true;
            }
            return false;
        }
    }

    class Part
    {
        private long energyConsumption;

        public Part()
        {
            energyConsumption = 0;
        }

        public Part(long energyConsumption)
        {
            this.energyConsumption = energyConsumption;
        }

        public long EnergyConsumption { get => energyConsumption; set => energyConsumption = value; }

        public override string ToString()
        {
            return $"###Energy consumption: {EnergyConsumption}\n";
        }
    }

    class Head : Part
    {
        private int iq;
        private string skin;

        public Head() : base()
        {
            this.iq = 0;
            this.skin = "";
        }

        public Head(long energy, int iq, string skin) : base(energy)
        {
            this.iq = iq;
            this.skin = skin;
        }

        public int Iq { get => iq; set => iq = value; }
        public string Skin { get => skin; set => skin = value; }

        public override string ToString()
        {
            string info = "#Head:\n" +
                          base.ToString() +
                          $"###IQ: {Iq}\n" +
                          $"###Skin material: {Skin}";
            return info;
        }
    }

    class Torso : Part
    {
        private double processorSize;
        private string corpus;

        public Torso() : base()
        {
            this.processorSize = 0.0;
            this.corpus = "";
        }

        public Torso(long energy, double processorSize, string corpus) : base(energy)
        {
            this.processorSize = processorSize;
            this.corpus = corpus;
        }

        public double ProcessorSize { get => processorSize; set => processorSize = value; }
        public string Corpus { get => corpus; set => corpus = value; }

        public override string ToString()
        {
            string info = "#Torso:\n" +
                          base.ToString() +
                          $"###Processor size: {string.Format("{0:0.0}", processorSize)}\n" +
                          $"###Corpus material: {corpus}";
            return info;
        }

    }

    class Arm : Part
    {
        private int reachDistance;
        private int fingers;

        public Arm() : base()
        {
            this.reachDistance = 0;
            this.fingers = 0;
        }

        public Arm(long energy, int reachDistance, int fingers) : base(energy)
        {
            this.reachDistance = reachDistance;
            this.fingers = fingers;
        }

        public int ReachDistance { get => reachDistance; set => reachDistance = value; }
        public int Fingers { get => fingers; set => fingers = value; }

        public override string ToString()
        {
            string info = "#Arm:\n" +
                          base.ToString() +
                          $"###Reach: {reachDistance}\n" +
                          $"###Fingers: {fingers}";
            return info;
        }
    }

    class Leg : Part
    {
        private int strength;
        private int speed;

        public Leg() : base()
        {
            this.strength = 0;
            this.speed = 0;
        }

        public Leg(long energy, int strength, int speed) : base(energy)
        {
            this.strength = strength;
            this.speed = speed;
        }

        public int Strength { get => strength; set => strength = value; }
        public int Speed { get => speed; set => speed = value; }

        public override string ToString()
        {
            string info = "#Leg:\n" +
                          base.ToString() +
                          $"###Strength: {strength}\n" +
                          $"###Speed: {speed}";
            return info;
        }
    }
}

