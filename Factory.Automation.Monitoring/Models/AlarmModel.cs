using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Automation.Monitoring.Models
{
    public class AlarmModel
    {
        public string DeviceNum { get; set; }
        public string DeviceName { get; set; }
        public string AlarmLevel { get; set; }
        public string LevelColor { get; set; }
        public string AlarmMessage { get; set; }
        public string AlarmTime { get; set; }
        public string ResumeTime { get; set; }
    }
}
