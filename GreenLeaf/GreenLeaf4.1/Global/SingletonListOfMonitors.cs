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
        /* Global List. This class is accessable in our whole application and may only be set once
* but called as many times as we want. This also why it may seems slow when we navigate between pages
* because we are calling and retrieving data from our web api which is getting the data from a database
* on Azure.
*/
        public static ObservableCollection<Monitor> ListOfMonitors;

        private static SingletonListOfMonitors Instance { get; set; }

        private SingletonListOfMonitors()
        {
            LoadMonitorList();
        }

        public  static void LoadMonitorList()
        {
            /* We call the Web api service class in our contructer because we want our data immediatly.
 * The data needs to be deserialize so that it can be displayed in the observablecollection.
 */
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
