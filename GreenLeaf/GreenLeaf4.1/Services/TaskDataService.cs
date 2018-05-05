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
    class TaskDataService
    {
        private static readonly SingletonListOfTasks Instance = SingletonListOfTasks.GetInstance();
        private static IEnumerable<Models.CTask> AllTasks()
        {
            return Instance.GetTaskList();
        }

        public static ObservableCollection<CTask> GetGridTasksData()
        {
            return new ObservableCollection<CTask>(AllTasks());
        }

        public static async Task<IEnumerable<CTask>> GetTaskModelDataAsync()
        {
            await Task.CompletedTask;
            return AllTasks();
        }
    }
}
