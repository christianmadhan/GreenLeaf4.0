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
   public static class MonitorDataService
    {
        private static readonly SingletonListOfMonitors Instance = SingletonListOfMonitors.GetInstance();
        private static IEnumerable<Monitor> AllMonitors()
        {
            return Instance.GetMonitorList();
        }

        public static ObservableCollection<Monitor> GetGridMonitorsData()
        {
            return new ObservableCollection<Monitor>(AllMonitors());
        }

        public static async Task<IEnumerable<Monitor>> GetMonitorModelDataAsync()
        {
            await Task.CompletedTask;
            return AllMonitors();
        }
    }
}
