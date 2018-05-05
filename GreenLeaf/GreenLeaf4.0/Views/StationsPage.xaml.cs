using System;

using GreenLeaf4._0.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf4._0.Views
{
    public sealed partial class StationsPage : Page
    {
        public StationsViewModel ViewModel { get; } = new StationsViewModel();

        public StationsPage()
        {
            InitializeComponent();
        }
    }
}
