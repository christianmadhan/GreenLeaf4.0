using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Models;

namespace GreenLeaf4._1.Utils
{
    class AccountHelper
    {
        private static SingletonListOfEmployees Instance = SingletonListOfEmployees.GetInstance();

        public static ObservableCollection<Employee> LoadAccountList()
        {
              return Instance.GetEmployeeList();
        }

        public static bool ValidateAccountCredentials(string username,string password)
        {
            foreach (var emp in Instance.GetEmployeeList())
            {
                if (emp.Username.Equals(username) && emp.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
