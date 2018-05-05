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
        public static ObservableCollection<Station> ListOfStations;

        private static SingletonListOfStations Instance { get; set; }

        private SingletonListOfStations()
        {
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
