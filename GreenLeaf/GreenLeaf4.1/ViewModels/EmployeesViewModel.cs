using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;

using Microsoft.Toolkit.Uwp.UI.Controls;

namespace GreenLeaf4._1.ViewModels
{
    public class EmployeesViewModel : Observable
    {
        private SingletonListOfEmployees Instance = SingletonListOfEmployees.GetInstance();
        private Employee _selected;

        public Employee Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<Employee> EmployeesSample = new ObservableCollection<Employee>();


        public EmployeesViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            EmployeesSample.Clear();


            foreach (var emp in Instance.GetEmployeeList())
            {
                EmployeesSample.Add(emp);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = EmployeesSample.First();
            }
        }
    }
}
