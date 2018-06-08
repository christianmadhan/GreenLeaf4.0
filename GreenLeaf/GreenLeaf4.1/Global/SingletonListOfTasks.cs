using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;
using Newtonsoft.Json;

namespace GreenLeaf4._1.Global
{
    public class SingletonListOfTasks
    {
        /* Global List. This class is accessable in our whole application and may only be set once
* but called as many times as we want. This also why it may seems slow when we navigate between pages
* because we are calling and retrieving data from our web api which is getting the data from a database
* on Azure.
*/
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
                ListOfTasks = Json.TransformData(data);
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
