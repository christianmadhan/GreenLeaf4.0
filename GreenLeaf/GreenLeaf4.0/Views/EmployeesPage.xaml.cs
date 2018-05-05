using System;

using GreenLeaf4._0.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GreenLeaf4._0.Views
{
    public sealed partial class EmployeesPage : Page
    {
        public EmployeesViewModel ViewModel { get; } = new EmployeesViewModel();

        public EmployeesPage()
        {
            InitializeComponent();
            Loaded += EmployeesPage_Loaded;
        }

        private async void EmployeesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
