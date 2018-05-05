using System;

using GreenLeaf.ViewModels;

using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;

namespace GreenLeaf.Views
{
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; } = new ShellViewModel();

        public ShellPage()
        {
            InitializeComponent();
            HideNavViewBackButton();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame, NavigationView);
        }

        private void HideNavViewBackButton()
        {
            if (ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 6))
            {
                NavigationView.IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed;
            }
        }
    }
}
