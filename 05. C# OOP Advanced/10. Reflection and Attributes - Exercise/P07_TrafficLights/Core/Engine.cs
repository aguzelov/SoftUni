using P07_TrafficLights.Enums;
using P07_TrafficLights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P07_TrafficLights.Core
{
    public class Engine
    {
        private readonly List<TrafficLight> trafficLights;

        public Engine()
        {
            this.trafficLights = new List<TrafficLight>();
        }

        public void Run()
        {
            SetLights();
            int trafficLightsChangeCount = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            foreach (var _ in Enumerable.Range(0, trafficLightsChangeCount))
            {
                this.trafficLights.ForEach(t => t.ChangeSignal());

                sb.AppendLine(string.Join(" ", this.trafficLights));
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private void SetLights()
        {
            string[] trafficLightSignals = Console.ReadLine().Split();

            foreach (var trafficLightSignal in trafficLightSignals)
            {
                if (Enum.TryParse(trafficLightSignal, out SignalState signal))
                {
                    this.trafficLights.Add(new TrafficLight(signal));
                }
            }
        }

        private string ChangeSignal(TrafficLight trafficLight)
        {
            trafficLight.ChangeSignal();
            string result = trafficLight.Signal.ToString();

            return result;
        }
    }
}