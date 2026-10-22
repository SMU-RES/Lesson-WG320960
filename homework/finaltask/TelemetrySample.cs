using System;

namespace task
{
    internal sealed class TelemetrySample
    {
        public DateTime TimestampUtc { get; set; }
        public double TemperatureC { get; set; }
        public double VoltageV { get; set; }
        public double Rpm { get; set; }
        public string Source { get; set; } // "SIM" | "COMx"
        public string Level { get; set; }  // "OK" | "WARN" | "ALARM"
    }
}
