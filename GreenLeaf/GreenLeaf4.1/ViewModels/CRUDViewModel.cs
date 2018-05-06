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
using GreenLeaf4._1.Services;
using GreenLeaf4._1.Views;

namespace GreenLeaf4._1.ViewModels
{
    public class CRUDViewModel : NotifyChanged
    {
        // New Station
        public string StationName { get; set; }
        public string Location { get; set; }
        public Station newStation { get; set; }

        // New Employee
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private string _userName;
        public string PassWord { get; set; }

        public Employee newEmp { get; set; }

        // New Task
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Status { get; set; }
        public Employee SelectedEmployeeComboBox { get; set; }

        public CTask newTask { get; set; }

        // New Monitor
        public string MonitorName { get; set; }
        public string Particle { get; set; }
        public string Equipment { get; set; }
        public Monitor newMonitor { get; set; }

        // New Comment
        public string CommentDescription { get; set; }
        public Comment newComment { get; set; }

        // The username has to implement the onpropertychanged because its a textbox
        public string UserName
        {
            get => _userName; 
            set { _userName = value; OnPropertyChanged(nameof(UserName)); }
        }

        //RelayCommands
        public RelayCommand GenerateUsername { get; set; }
        public RelayCommand CreateEmployee { get; set; }
        public RelayCommand CreateTask { get; set; }
        public RelayCommand CreateMonitor { get; set; }
        public RelayCommand CreateComment { get; set; }
        public RelayCommand CreateStation { get; set; }

        //------------------------------------------------------
        //Singleton List classes
        private SingletonListOfEmployees emplist = SingletonListOfEmployees.GetInstance();
        private SingletonListOfTasks tasklist = SingletonListOfTasks.GetInstance();
        private SingletonListOfMonitors monitorlist = SingletonListOfMonitors.GetInstance();
        private SingletonListOfComments commentlist = SingletonListOfComments.GetInstance();
        private SingletonListOfStations stationList = SingletonListOfStations.GetInstance();

        //Singleton model classes
        private SingletonStation station = SingletonStation.GetInstance();
        
        //------------------------------------------------------
        public ObservableCollection<Employee> emps { get; set; }
        public ObservableCollection<Station> stations { get; set; }

        // Constructer
        public CRUDViewModel()
        {
            stations = new ObservableCollection<Station>();
            emps = new ObservableCollection<Employee>();
            newEmp = new Employee();
            newTask = new CTask();
            newMonitor = new Monitor();
            newComment = new Comment();
            newStation = new Station();
            LoadDataIntoLists();

            GenerateUsername = new RelayCommand(DoGenerateUsername);
            CreateEmployee = new RelayCommand(DoCreateEmployee);
            CreateTask = new RelayCommand(DoCreateTask);
            CreateMonitor = new RelayCommand(DoCreateMonitor);
            CreateComment = new RelayCommand(DoCreateComment);
            CreateStation = new RelayCommand(DoCreateStation);
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
            try
            {
                    emplist.GetEmployeeList().GroupBy(x => x.EmpID);
                    newEmp.EmpID = emplist.GetEmployeeList().Last().EmpID + 1;
                    newEmp.Firstname = FirstName;
                    newEmp.Lastname = LastName;
                    newEmp.Username = UserName;
                    newEmp.Password = PassWord;


                    emplist.GetEmployeeList().Add(newEmp);
                    MessageDialog msg = new MessageDialog("The User " + UserName + " has been added");
                    await msg.ShowAsync();
                     await WebApiService.PostTMECS("api/Employees", newEmp);
                    Window.Current.Close();                
            }
            catch (Exception e)
            {
                MessageDialog msg = new MessageDialog("Something bad happened: " + e.Message);
                await msg.ShowAsync();
            }
        }

        public async void DoCreateTask()
        {
            tasklist.GetTaskList().GroupBy(x => x.TaskID);
            newTask.TaskID = tasklist.GetTaskList().Last().TaskID + 1;
            newTask.Description = Description;
            newTask.Date = Date.Date.ToShortDateString();
            newTask.Status = Status;
            newTask.EmpID = SelectedEmployeeComboBox.EmpID;
            newTask.StationID = station.GetStationID();

            tasklist.GetTaskList().Add(newTask);

            MessageDialog msg = new MessageDialog(" The task: " + newTask.Description + "\n" + "Has been assigned to " + SelectedEmployeeComboBox.Firstname);
            await msg.ShowAsync();
            await WebApiService.PostTMECS("api/Tasks", newTask);
            Window.Current.Close();
        }

        public async void DoCreateMonitor()
        {
            monitorlist.GetMonitorList().GroupBy(x => x.MonitorID);
            newMonitor.MonitorID = monitorlist.GetMonitorList().Last().MonitorID + 1;
            newMonitor.Name = MonitorName;
            newMonitor.Particle = Particle;
            newMonitor.Equipment = Equipment;
            newMonitor.StationID = station.GetStationID();

            monitorlist.GetMonitorList().Add(newMonitor);

            MessageDialog msg = new MessageDialog("The Monitor " + MonitorName + " has been added to the Station");
            await msg.ShowAsync();
            await WebApiService.PostTMECS("api/Monitors", newMonitor);
            Window.Current.Close();

        }

        public async void DoCreateComment()
        {
            commentlist.GetCommentsList().GroupBy(x => x.CommentID);
            newComment.CommentID = commentlist.GetCommentsList().Last().CommentID + 1;
            newComment.Description = CommentDescription;
            newComment.StationID = station.GetStationID();

            commentlist.GetCommentsList().Add(newComment);

            MessageDialog msg = new MessageDialog("The Comment: " + CommentDescription + "\n" + "Has been added");
            await msg.ShowAsync();
            await WebApiService.PostTMECS("api/Comments", newComment);
            Window.Current.Close();
        }

        public async void DoCreateStation()
        {
            stationList.GetStationList().GroupBy(x => x.StationID);
            newStation.StationID = stationList.GetStationList().Last().StationID + 1;
            newStation.Name = StationName;
            newStation.Location = Location;

            stationList.GetStationList().Add(newStation);

            MessageDialog msg = new MessageDialog("The Station: " + StationName + " Has been added");
            await msg.ShowAsync();
            await WebApiService.PostTMECS("api/Stations", newStation);
            Window.Current.Close();
        }
    }
}
