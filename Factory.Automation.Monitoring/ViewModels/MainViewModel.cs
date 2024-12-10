using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Factory.Automation.Monitoring.Models;

namespace Factory.Automation.Monitoring.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<AlarmModel> AlarmList { get; set; }

        private CancellationTokenSource cts = new CancellationTokenSource();
        public List<DeviceModel> DeviceList { get; set; } = new List<DeviceModel>();

        public MainViewModel()
        {
            #region Test data
            AlarmList = new ObservableCollection<AlarmModel>();
            AlarmList.Add(new AlarmModel()
            {
                DeviceNum = "000-0000",
                DeviceName = "robot",
                AlarmLevel = "Serious",
                LevelColor = "Orange",
                AlarmMessage = "xxx",
                AlarmTime = "20:00",
                ResumeTime = "20:00",
            });
            AlarmList.Add(new AlarmModel()
            {
                DeviceNum = "000-0000",
                DeviceName = "robot",
                AlarmLevel = "General",
                LevelColor = "#729BDF",
                AlarmMessage = "xxx",
                AlarmTime = "20:00",
                ResumeTime = "20:00",
            });
            AlarmList.Add(new AlarmModel()
            {
                DeviceNum = "000-0000",
                DeviceName = "robot",
                AlarmLevel = "Urgent",
                LevelColor = "#FE644A",
                AlarmMessage = "xxx",
                AlarmTime = "20:00",
                ResumeTime = "20:00",
            });
            AlarmList.Add(new AlarmModel()
            {
                DeviceNum = "000-0000",
                DeviceName = "robot",
                AlarmLevel = "Serious",
                LevelColor = "Orange",
                AlarmMessage = "xxx",
                AlarmTime = "20:00",
                ResumeTime = "20:00",
            });
            #endregion

            DeviceModel dm = new DeviceModel();
            dm.IP = "192.168.2.1";
            dm.Port = 102;
            dm.VarList.Add(new VariableModel { VarName = "Idle Running Speed", VarAddress = "DB1.DBW0" });
            dm.VarList.Add(new VariableModel { VarName = "Spindle Speed", VarAddress = "DB1.DBW2" });
            DeviceList.Add(dm);

            //dm = new DeviceModel();
            //dm.IP = "192.168.2.2";
            //dm.Port = 102;
            //dm.VarList.Add(new VariableModel { VarName = "Idle Running Speed", VarAddress = "DB1.DBW0" });
            //dm.VarList.Add(new VariableModel { VarName = "Spindle Speed", VarAddress = "DB1.DBW2" });
            //dm.VarList.Add(new VariableModel { VarName = "Feed Rate", VarAddress = "DB1.DBW4" });
            //DeviceList.Add(dm);


            // Start monitoring
            // 1. There are many devices
            // 2. There are also many variables in each device
            foreach (var device in DeviceList)
            {
                Task.Run(() =>
                {
                    // Connected to the device
                    S7.Net.Plc plc = new S7.Net.Plc(S7.Net.CpuType.S71200, device.IP, 0, 0);
                    plc.Open();
                    // Loop to obtain

                    while (!cts.IsCancellationRequested)
                    {
                        // Reconnection mechanism: Heartbeat
                        // Request a status from the device, which is a very efficient communication
                        // If no status is obtained, timeout, disconnect the connection
                        // Start reconnection here
                        // If there is no problem
                        // Start the following variable acquisition
                        if (plc.IsConnected)
                            // There are many variables; it is not recommended to fetch all external variables at once; judge and package some addresses accordingly.
                            foreach (var v in device.VarList)
                            {
                                v.Value = plc.Read(v.VarAddress);

                                // Alarm judgment
                            }
                    }
                });
            }
            //var thread = new Thread(new ThreadStart(() =>
            //   {
            //       while (!cts.IsCancellationRequested)
            //       {

            //       }
            //   }));

            //thread.IsBackground = true;
            //thread.Start();
        }
    }
}
