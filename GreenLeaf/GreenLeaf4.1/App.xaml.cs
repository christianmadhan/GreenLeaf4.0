using System;

using GreenLeaf4._1.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using GreenLeaf4._1.Global;

namespace GreenLeaf4._1
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();

            SingletonListOfComments CommentSingle = SingletonListOfComments.GetInstance();
            SingletonListOfEmployees EmployeeSingle = SingletonListOfEmployees.GetInstance();
            SingletonListOfMonitors MonitorSingle  = SingletonListOfMonitors.GetInstance();
            SingletonListOfStations StationSingle = SingletonListOfStations.GetInstance();
            SingletonListOfTasks TaskSingle = SingletonListOfTasks.GetInstance();
           
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.GreenLeafPage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
