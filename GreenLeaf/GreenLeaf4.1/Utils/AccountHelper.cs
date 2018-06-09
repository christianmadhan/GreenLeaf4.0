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
    /* This is the class that handles the login process. normally the accounthelper class is used
     * to handle the windows pin login, so that you can log into any application if you have set the window pin
     * but in this case i thought that it made more sense to use the employees password since that we have that in
     * our database.
     */
    class AccountHelper
    {

        // We need the global list to check if the credential that the user input match any employee in the system.
        private static SingletonListOfEmployees Instance = SingletonListOfEmployees.GetInstance();

        // When we get a succesfully login the employee who is logged in will be set to the global emp
        // Which we later can refer to, we do this in the employee page, where we sort the task list based on who is logged in.
        private static SingletonEmployee singleEmp = SingletonEmployee.GetInstance();

        // This method is used inside the Login.xaml.cs
        // We loop through the whole emp list to check if the credentials match.
        //The set the global emp as the emp who is logged in.
        // The method returns false if there is no emp with the given credentials 
        public static bool ValidateAccountCredentials(string username,string password)
        {
            foreach (var emp in Instance.GetEmployeeList())
            {
                if (emp.Username.Equals(username) && emp.Password.Equals(password))
                {
                    singleEmp.SetEmployee(emp);
                    return true;
                }
            }
            return false;
        }
    }
}
