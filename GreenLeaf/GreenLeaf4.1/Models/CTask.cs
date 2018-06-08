using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
    /* Inherits the INotifyChanged Property Class
 * This makes sure that the model get updated when we make changes
 * in the view
*/

   // Also notice that the class is named CTask and not just Task.
   // Thats because there is a class called Task in C# and its bad design to class this class Task.
    public class CTask : Observable
    {
        //Private properties
        private int _taskID;
        private string _description;
        private DateTime _date;
        private string _status;
        private int _empID;
        private int _stationID;

       /*Constructer for the class, its important that the properties of the object
         * Is the same as the fields in the database. */
        public CTask(int taskID, string description, DateTime date, string status, int empID, int stationID)
        {
            _taskID = taskID;
            _description = description;
            _date = date;
            _status = status;
            _empID = empID;
            _stationID = stationID;
        }

        //Empty Constructer for singleton 
        public CTask() { }


        //-----------------------------------------------------------------------------------
        // Get and set Methods
        // On the set method we use the OnPropertyChanged method 
        public int TaskID
        {
            get { return _taskID; }
            set { _taskID = value; OnPropertyChanged(nameof(TaskID)); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public DateTime Date
        {
            get => _date.Date;
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        public int EmpID
        {
            get { return _empID; }
            set { _empID = value; OnPropertyChanged(nameof(EmpID)); }
        }
        public int StationID
        {
            get { return _stationID; }
            set { _stationID = value; OnPropertyChanged(nameof(StationID)); }
        }
    }
}
