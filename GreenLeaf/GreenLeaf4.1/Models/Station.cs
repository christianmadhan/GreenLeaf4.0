using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
    public class Station : NotifyChanged
    {
        private int _stationID;
        private string _name;
        private string _location;

        public Station(int stationID, string name, string location)
        {
            _stationID = stationID;
            _name = name;
            _location = location;
        }

        public Station() { }

        public int StationID
        {
            get { return _stationID; }
            set { _stationID = value; OnPropertyChanged(nameof(StationID)); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; OnPropertyChanged(nameof(Location)); }
        }
    }
}
