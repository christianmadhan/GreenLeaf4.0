using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Models;

namespace GreenLeaf4._1.Global
{
  public  class SingletonEmployee 
  {
    /* Global  Employee Object. Whent the user log into the system
     * The account helper class (The class that manage login) goes through the Employee List
     * Check to see that the credential match, if they do they set the employee who is log in to the global employee.
     * There can only be one global instance of this class.
     */
      public static Employee _Employee;

        private static SingletonEmployee Instance { get; set; }

      private SingletonEmployee()
      {
          _Employee = new Employee();
      }

      public static SingletonEmployee GetInstance()
      {
          if (Instance == null)
          {
              Instance = new SingletonEmployee();
          }
          return Instance;
        }

      public void SetEmployee(Employee employee)
      {
          _Employee = employee;
      }


      public int GetEmployeeID()
      {
          return _Employee.EmpID;
      }

      public string GetFirstName()
      {
          return _Employee.Firstname;
      }

      public string GetLastName()
      {
          return _Employee.Lastname;
      }

      public string GetUserName()
      {
          return _Employee.Username;
      }

      public string GetPassword()
      {
          return _Employee.Password;
      }
    }
}
