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
    public class SingletonListOfTasks
    {
        public static ObservableCollection<CTask> ListOfTasks;

        private static SingletonListOfTasks Instance { get; set; }

        private SingletonListOfTasks()
        {
            LoadTaskList();
        }

        public static void LoadTaskList()
        {
            try
            {
                var data = WebApiService.GetDataFromWeb("api/Tasks");
                ListOfTasks = JsonConvert.DeserializeObject<ObservableCollection<CTask>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static SingletonListOfTasks GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonListOfTasks();
            }
            return Instance;
        }

        public void SetTaskList(ObservableCollection<CTask> listTask)
        {
            ListOfTasks = listTask;
        }

        public ObservableCollection<CTask> GetTaskList()
        {
            return ListOfTasks;
        }

        public void LoadNewTask()
        {
            LoadTaskList();
            Instance.GetTaskList();
        }

    }
}
