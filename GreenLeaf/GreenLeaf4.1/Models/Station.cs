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
    public class Station : Observable
    {
        //Private Properties
        private int _stationID;
        private string _name;
        private string _location;

        /*Constructer for the class, its important that the properties of the object
         * Is the same as the fields in the database. */
        public Station(int stationID, string name, string location)
        {
            _stationID = stationID;
            _name = name;
            _location = location;
        }

        //Empty Constructer for singleton
        public Station() { }


        //-----------------------------------------------------------------------------------
        // Get and set Methods
        // On the set method we use the OnPropertyChanged method 
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
