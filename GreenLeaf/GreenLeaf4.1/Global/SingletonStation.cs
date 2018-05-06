using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Models;

namespace GreenLeaf4._1.Global
{
    public class SingletonStation
    {
        public static Station _Station;

        private static SingletonStation Instance { get; set; }

        private SingletonStation()
        {
            _Station = new Station();
        }

        public static SingletonStation GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonStation();
            }
            return Instance;
        }

        public void SetStation(Station station)
        {
            _Station = station;
        }


        public int GetStationID()
        {
            return _Station.StationID;
        }

        public string GetName()
        {
            return _Station.Name;
        }

        public string GetLocation()
        {
            return _Station.Location;
        }
    }
}
