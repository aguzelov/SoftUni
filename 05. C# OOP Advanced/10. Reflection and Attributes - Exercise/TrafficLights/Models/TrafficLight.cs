using P07_TrafficLights.Enums;
using System;
using System.Collections.Generic;

namespace P07_TrafficLights.Models
{
    public class TrafficLight
    {
        private Queue<SignalState> signals;

        public TrafficLight(SignalState signal)
        {
            this.signals = new Queue<SignalState>();
            SetSignals(signal);
        }

        private void SetSignals(SignalState signal)
        {
            int signalsCount = Enum.GetNames(typeof(SignalState)).Length;
            var currentSignal = signal;

            while (this.signals.Count != signalsCount)
            {
                this.signals.Enqueue(currentSignal);

                var nextSignal = (int)currentSignal + 1;
                if (nextSignal == signalsCount)
                {
                    nextSignal = 0;
                }

                currentSignal = (SignalState)nextSignal;
            }
        }

        public SignalState Signal => this.signals.Peek();

        public void ChangeSignal()
        {
            var oldSignal = this.signals.Dequeue();
            this.signals.Enqueue(oldSignal);
        }

        public override string ToString()
        {
            return this.Signal.ToString();
        }
    }
}