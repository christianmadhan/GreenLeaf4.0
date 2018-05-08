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
