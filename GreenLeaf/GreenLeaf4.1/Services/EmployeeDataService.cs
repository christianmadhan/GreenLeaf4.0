using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Models;

namespace GreenLeaf4._1.Services
{
    public static class EmployeeDataService
    {
        private static readonly SingletonListOfEmployees Instance = SingletonListOfEmployees.GetInstance();
        private static IEnumerable<Employee> AllEmployees()
        {
            return Instance.GetEmployeeList();
        }

        public static ObservableCollection<Employee> GetGridEmployeeData()
        {
            return new ObservableCollection<Employee>(AllEmployees());
        }

        public static async Task<IEnumerable<Employee>> GetEmployeeModelDataAsync()
        {
            await Task.CompletedTask;
            return AllEmployees();
        }
    }
}
