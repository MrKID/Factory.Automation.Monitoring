using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Automation.Monitoring.Models
{
    public class DeviceModel
    {
        //public string SpeedIdleAddress { get; set; }
        //// Idle Running Speed
        //public double SpeedIdle { get; set; }
        //// Spindle Speed、Feed Rate
        //public double SpeedMainAxis { get; set; }
        //public double FeedRate { get; set; }

        //// Temperature, Vibration, Noise, Oil Fluid
        //public double Temperature { get; set; }
        //public double VibrationFrequency { get; set; }
        //public double Noise { get; set; }
        //public double OilQuantity { get; set; }
        //public double OilTemperature { get; set; }
        //// Cutting Fluid, Coolant

        //// Workpiece Count, Processing Time
        //public double WorkpieceCount { get; set; }
        //public double ProcessingDuration { get; set; }

        public string IP { get; set; }
        public int Port { get; set; }

        public List<VariableModel> VarList { get; set; } = new List<VariableModel>();
    }
}
