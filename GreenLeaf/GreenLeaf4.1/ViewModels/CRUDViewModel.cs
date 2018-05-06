using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Views;

namespace GreenLeaf4._1.ViewModels
{
    public class CRUDViewModel : NotifyChanged
    { 
        //Employee
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string _userName;
        public string PassWord { get; set; }

        public Employee newEmp { get; set; }

        // The username has to implement the onpropertychanged because its a textbox
        public string UserName
        {
            get => _userName; 
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        //RelayCommands
        public RelayCommand GenerateUsername { get; set; }
        public RelayCommand CreateEmployee { get; set; }

        //------------------------------------------------------
        //Singleton List classes
        private SingletonListOfEmployees emplist = SingletonListOfEmployees.GetInstance();
        private SingletonListOfStations stationList = SingletonListOfStations.GetInstance();

        //Singleton model classes
        private SingletonStation station = SingletonStation.GetInstance();
        private SingletonEmployee globalEmp = SingletonEmployee.GetInstance();
        
        //------------------------------------------------------
        public ObservableCollection<Employee> emps { get; set; }
        public ObservableCollection<Station> stations { get; set; }

        // Constructer
        public CRUDViewModel()
        {
            stations = new ObservableCollection<Station>();
            emps = new ObservableCollection<Employee>();
            newEmp = new Employee();
            LoadDataIntoLists();

            GenerateUsername = new RelayCommand(DoGenerateUsername);
            CreateEmployee = new RelayCommand(DoCreateEmployee);
        }

        public void LoadDataIntoLists()
        {
            foreach (var e in emplist.GetEmployeeList())
            {
                emps.Add(e);
            }

            foreach (var s in stationList.GetStationList() )
            {
                stations.Add(s);
            }
        }

        // Generates a username based on the input boxes
        public void DoGenerateUsername()
        {
            Random r1 = new Random();
            string first = FirstName.Substring(0, 2);
            string second = LastName.Substring(0, 2);
            int randomNum = r1.Next(20, 400);

            UserName = first + second + randomNum;
        }

        public async void DoCreateEmployee()
        {
            emplist.GetEmployeeList().GroupBy(x => x.EmpID);
            newEmp.EmpID = emplist.GetEmployeeList().Last().EmpID + 1;
            newEmp.Firstname = FirstName;
            newEmp.Lastname = LastName;
            newEmp.Username = UserName;
            newEmp.Password = PassWord;

            emplist.GetEmployeeList().Add(newEmp);
            MessageDialog msg = new MessageDialog("The user " + UserName + " has been added");
            await msg.ShowAsync();
            Window.Current.Close();
        }
    }
}
