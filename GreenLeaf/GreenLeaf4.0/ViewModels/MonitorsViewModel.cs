using System;
using System.Collections.ObjectModel;

using GreenLeaf4._0.Helpers;
using GreenLeaf4._0.Models;
using GreenLeaf4._0.Services;

namespace GreenLeaf4._0.ViewModels
{
    public class MonitorsViewModel : Observable
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
