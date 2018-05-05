using System;
using System.Collections.ObjectModel;

using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;

namespace GreenLeaf4._1.ViewModels
{
    public class TasksViewModel : Observable
    {
        public ObservableCollection<CTask> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return TaskDataService.GetGridTasksData();
            }
        }
    }
}
