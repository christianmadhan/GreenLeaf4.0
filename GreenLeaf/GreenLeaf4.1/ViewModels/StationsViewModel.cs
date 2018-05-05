using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Popups;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Controls;

namespace GreenLeaf4._1.ViewModels
{
    public class StationsViewModel : Observable
    {
        private Station _selected;
        public RelayCommand NeedNewName { get; set; }

        SingletonListOfComments Comments = SingletonListOfComments.GetInstance();
        SingletonListOfMonitors Monitors = SingletonListOfMonitors.GetInstance();
        SingletonListOfTasks Tasks = SingletonListOfTasks.GetInstance();

        ObservableCollection<CTask> NewTask = new ObservableCollection<CTask>();

        public Station Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }


        public ObservableCollection<Station> StationSample = new ObservableCollection<Station>();
        public ObservableCollection<CTask> LocalTaskList = new ObservableCollection<CTask>();
        public SingletonListOfStations Instance = SingletonListOfStations.GetInstance();

        public StationsViewModel()
        {
            LoadData();
            LoadLocal();
            NeedNewName = new RelayCommand(DoNewThings);

        }

        public void LoadData()
        {

            foreach (var station in Instance.GetStationList())
            {
                StationSample.Add(station);
            }

        }

        public void LoadLocal()
        {

            foreach (var cTask in Tasks.GetTaskList())
            {
                LocalTaskList.Add(cTask);
            }

        }

        public void DoNewThings()
        {
       
        }
    }
}
