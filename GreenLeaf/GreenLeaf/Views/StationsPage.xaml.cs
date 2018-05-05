using System;

using GreenLeaf.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf.Views
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
