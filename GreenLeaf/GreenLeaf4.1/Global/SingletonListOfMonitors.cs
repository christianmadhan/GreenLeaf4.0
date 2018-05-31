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
    public class SingletonListOfMonitors
    {
        public static ObservableCollection<Monitor> ListOfMonitors;

        private static SingletonListOfMonitors Instance { get; set; }

        private SingletonListOfMonitors()
        {
            LoadMonitorList();
        }

        public  static void LoadMonitorList()
        {
            try
            {
                var data =  WebApiService.GetDataFromWeb("api/Monitors");
                 ListOfMonitors = JsonConvert.DeserializeObject<ObservableCollection<Monitor>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static SingletonListOfMonitors GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonListOfMonitors();
            }
            return Instance;
        }

        public void SetMonitorList(ObservableCollection<Monitor> listMonitor)
        {
            ListOfMonitors = listMonitor;
        }

        public ObservableCollection<Monitor> GetMonitorList()
        {
            return ListOfMonitors;
        }
    }
}
