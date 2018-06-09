using System;

using GreenLeaf4._1.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Views;

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
            //_activationService = new Lazy<ActivationService>(CreateActivationService);
            _activationService = new Lazy<ActivationService>(CreateLogin);
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

        private ActivationService CreateLogin()
        {
            return new ActivationService(this,typeof(Login));
        }

    }
}
