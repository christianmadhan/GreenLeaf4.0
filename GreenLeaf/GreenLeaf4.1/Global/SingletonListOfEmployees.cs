using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;
using Newtonsoft.Json;

namespace GreenLeaf4._1.Global
{
    public class SingletonListOfEmployees
    {
     /* Global List. This class is accessable in our whole application and may only be set once
 * but called as many times as we want. This also why it may seems slow when we navigate between pages
 * because we are calling and retrieving data from our web api which is getting the data from a database
 * on Azure.
 */
        public static ObservableCollection<Employee> ListOfEmployees;

        private static SingletonListOfEmployees Instance { get; set; }

        private SingletonListOfEmployees()
        {
            /* We call the Web api service class in our contructer because we want our data immediatly.
 * The data needs to be deserialize so that it can be displayed in the observablecollection.
 */
            LoadEmployeeList();
        }

        public static void LoadEmployeeList()
        {
            try
            {
                var data = WebApiService.GetDataFromWeb("api/Employees");
                ListOfEmployees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static SingletonListOfEmployees GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonListOfEmployees();
            }
            return Instance;
        }

        public void SetEmployeeList(ObservableCollection<Employee> listEmployee)
        {
            ListOfEmployees = listEmployee;
        }

        public ObservableCollection<Employee> GetEmployeeList()
        {
            return ListOfEmployees;
        }


    }
}
