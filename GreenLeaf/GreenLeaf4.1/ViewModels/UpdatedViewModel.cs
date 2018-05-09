using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;

namespace GreenLeaf4._1.ViewModels
{
    class UpdatedViewModel : Observable
    {
        private readonly SingletonTask Instances = SingletonTask.GetInstance();
        private readonly SingletonListOfTasks listOfTask = SingletonListOfTasks.GetInstance();
        private CTask newTask = new CTask();
        private string _status;

        public RelayCommand UpdateStatus { get; set; }

        public string Status
        {
            get => _status;
            set{ Set(ref _status, value); }
        }

        public string Description { get; }
        public int TaskID { get; }

        public UpdatedViewModel()
        {
            _status = Instances.GetStatus();
            Description = Instances.GetDescription();
            TaskID = Instances.GetTaskID();
            UpdateStatus = new RelayCommand(DoUpdateStatus);
        }

        public async void DoUpdateStatus()
        {
            try
            {
                newTask.TaskID = Instances.GetTaskID();
                newTask.Description = Instances.GetDescription();
                newTask.Date = Instances.GetDate();
                newTask.Status = Status;
                newTask.EmpID = Instances.GetEmpID();
                newTask.StationID = Instances.GetStationID();

                //Instances.SetTask(newTask);

                //Instances.GetStatus();

               var item = listOfTask.GetTaskList().First(x => x.TaskID == Instances.GetTaskID());
                listOfTask.GetTaskList().Remove(item);
                listOfTask.GetTaskList().Add(newTask);

               await  WebApiService.DeleteObjectAsync("api/Tasks/" + item.TaskID);
                await WebApiService.PostTMECS("api/Tasks", newTask);

                MessageDialog msg = new MessageDialog("The Status had been Updated!");
                await msg.ShowAsync();
                Window.Current.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
