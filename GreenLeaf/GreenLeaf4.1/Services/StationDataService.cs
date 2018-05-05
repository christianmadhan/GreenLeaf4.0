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
    public static class StationDataService
    {
        private static readonly SingletonListOfStations Instance = SingletonListOfStations.GetInstance();
        private static IEnumerable<Station> AllStations()
        {
            return Instance.GetStationList();
        }

        public static ObservableCollection<Station> GetGridStationData()
        {
            return new ObservableCollection<Station>(AllStations());
        }

        public static async Task<IEnumerable<Station>> GetStationModelDataAsync()
        {
            await Task.CompletedTask;
            return AllStations();
        }
    }
}
