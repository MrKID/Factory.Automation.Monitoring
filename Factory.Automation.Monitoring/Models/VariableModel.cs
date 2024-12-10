using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Automation.Monitoring.Models
{
    public class VariableModel : INotifyPropertyChanged
    {
        public string VarName { get; set; }
        public string VarAddress { get; set; }
        private object _value;

        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
            }
        }

        public string Unit { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
