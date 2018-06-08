using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{

    /* Inherits the INotifyChanged Property Class
     * This makes sure that the model get updated when we make changes
    * in the view  */
    public class Employee : Observable
    {
        //Private Properties
        private int _empID;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _passWord;

        /*Constructer for the class, its important that the properties of the object
          * Is the same as the fields in the database.*/
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

        //-----------------------------------------------------------------------------------
        // Get and set Methods
        // On the set method we use the OnPropertyChanged method 
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

        // Tostring method, used in debugging when i tested if the employee
        // Object was retrived right
        public override string ToString()
        {
            return Firstname;
        }

        
    }
}
