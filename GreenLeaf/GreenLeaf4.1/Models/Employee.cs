using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
    public class Employee : Observable
    {
        private int _empID;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _passWord;

        public Employee(int empID, string firstname, string lastname, string username, string password)
        {
            _empID = empID;
            _firstName = firstname;
            _lastName = lastname;
            _userName = username;
            _passWord = password;
        }

        // Empty Constructer used for singleton
        public Employee() { }

        public int EmpID
        {
            get { return _empID; }
            set { _empID = value; OnPropertyChanged(nameof(EmpID)); }
        }

        public string Firstname
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(Firstname)); }
        }

        public string Lastname
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(Lastname)); }
        }

        public string Username
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return _passWord; }
            set { _passWord = value; OnPropertyChanged(nameof(Password)); }
        }

        public override string ToString()
        {
            return Firstname;
        }
    }
}
