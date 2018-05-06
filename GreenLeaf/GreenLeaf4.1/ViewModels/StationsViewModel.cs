using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;
using GreenLeaf4._1.Views;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Controls;

namespace GreenLeaf4._1.ViewModels
{
    public class StationsViewModel : Observable
    {
        private Station _selected;
        public static int Number = 0;

        SingletonStation _StationSingleton = SingletonStation.GetInstance();
        SingletonListOfComments Comments = SingletonListOfComments.GetInstance();
        SingletonListOfMonitors Monitors = SingletonListOfMonitors.GetInstance();
        SingletonListOfTasks Tasks = SingletonListOfTasks.GetInstance();

        public RelayCommand GoToCrudPage { get; set; }

        ObservableCollection<CTask> NewTask = new ObservableCollection<CTask>();

        public Station Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }


        public ObservableCollection<Station> StationSample = new ObservableCollection<Station>();
        public SingletonListOfStations Instance = SingletonListOfStations.GetInstance();

        public StationsViewModel()
        {
            LoadData();

            GoToCrudPage = new RelayCommand(DoGoToCrudPage);
           

        }

        public void LoadData()
        {
            foreach (var station in Instance.GetStationList())
            {
                StationSample.Add(station);
            }
        }

        public async void DoGoToCrudPage()
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 0;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(CrudTMEC), null);
                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();

                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }



    }
}
