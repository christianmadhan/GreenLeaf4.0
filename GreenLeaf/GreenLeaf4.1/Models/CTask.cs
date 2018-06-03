using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
    public class CTask : Observable
    {
        private int _taskID;
        private string _description;
        private DateTime _date;
        private string _status;
        private int _empID;
        private int _stationID;

        public CTask(int taskID, string description, DateTime date, string status, int empID, int stationID)
        {
            _taskID = taskID;
            _description = description;
            _date = date;
            _status = status;
            _empID = empID;
            _stationID = stationID;
        }

        public CTask() { }

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
            get => DateTimeConverter.DateConverter(_date.Year, _date.Month, _date.Day);
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
