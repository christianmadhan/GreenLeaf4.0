using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
    /* Inherits the INotifyChanged Property Class
 * This makes sure that the model get updated when we make changes
 * in the view */
    public class Monitor : Observable
    {
        //Private Properties
        private int _monitorID;
        private string _name;
        private string _particle;
        private string _equipment;
        private int _stationID;

        /*Constructer for the class, its important that the properties of the object
         * Is the same as the fields in the database.*/
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

        //-----------------------------------------------------------------------------------
        // Get and set Methods
        // On the set method we use the OnPropertyChanged method 
        public int MonitorID
        {
            get => _monitorID;
            set { _monitorID = value; OnPropertyChanged(nameof(MonitorID)); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Particle
        {
            get => _particle;
            set { _particle = value; OnPropertyChanged(nameof(Particle)); }
        }

        public string Equipment
        {
            get => _equipment;
            set { _equipment = value; OnPropertyChanged(nameof(Equipment)); }
        }

        public int StationID
        {
            get => _stationID;
            set { _stationID = value; OnPropertyChanged(nameof(StationID)); }
        }

    }
}
