using System;
using System.Collections.ObjectModel;

using GreenLeaf.Helpers;
using GreenLeaf.Models;
using GreenLeaf.Services;

namespace GreenLeaf.ViewModels
{
    public class TasksViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
