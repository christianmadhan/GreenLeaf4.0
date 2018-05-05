using System;

using GreenLeaf4._0.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf4._0.Views
{
    public sealed partial class GreenLeafPage : Page
    {
        public GreenLeafViewModel ViewModel { get; } = new GreenLeafViewModel();

        public GreenLeafPage()
        {
            InitializeComponent();
        }
    }
}
