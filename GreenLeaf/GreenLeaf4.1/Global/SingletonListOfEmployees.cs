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
        public static ObservableCollection<Employee> ListOfEmployees;

        private static SingletonListOfEmployees Instance { get; set; }

        private SingletonListOfEmployees()
        {
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
