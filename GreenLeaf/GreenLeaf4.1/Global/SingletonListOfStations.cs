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
    public class SingletonListOfStations
    {
        /* Global List. This class is accessable in our whole application and may only be set once
* but called as many times as we want. This also why it may seems slow when we navigate between pages
* because we are calling and retrieving data from our web api which is getting the data from a database
* on Azure.
*/
        public static ObservableCollection<Station> ListOfStations;

        private static SingletonListOfStations Instance { get; set; }

        private SingletonListOfStations()
        {
            /* We call the Web api service class in our contructer because we want our data immediatly.
 * The data needs to be deserialize so that it can be displayed in the observablecollection.
 */
            LoadStationList();
        }

        public static void LoadStationList()
        {
            try
            {
                var data = WebApiService.GetDataFromWeb("api/Stations");
                ListOfStations = JsonConvert.DeserializeObject<ObservableCollection<Station>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static SingletonListOfStations GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonListOfStations();
            }
            return Instance;
        }

        public void SetStationList(ObservableCollection<Station> listStations)
        {
            ListOfStations = listStations;
        }

        public ObservableCollection<Station> GetStationList()
        {
            return ListOfStations;
        }
    }
}
