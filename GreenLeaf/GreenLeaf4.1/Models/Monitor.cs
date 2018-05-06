using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
   public class Monitor : NotifyChanged
    {
        private int _monitorID;
        private string _name;
        private string _particle;
        private string _equipment;
        private int _stationID;

        public Monitor(int monitorID, string name, string particle, string equipment, int stationID)
        {
            _monitorID = monitorID;
            _name = name;
            _particle = particle;
            _equipment = equipment;
            _stationID = stationID;
        }

        // Empty Constructer for singleton
        public Monitor() { }

        public int MonitorID
        {
            get { return _monitorID; }
            set { _monitorID = value; OnPropertyChanged(nameof(MonitorID)); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Particle
        {
            get { return _particle; }
            set { _particle = value; OnPropertyChanged(nameof(Particle)); }
        }

        public string Equipment
        {
            get { return _equipment; }
            set { _equipment = value; OnPropertyChanged(nameof(Equipment)); }
        }

        public int StationID
        {
            get { return _stationID; }
            set { _stationID = value; OnPropertyChanged(nameof(StationID)); }
        }

    }
}
