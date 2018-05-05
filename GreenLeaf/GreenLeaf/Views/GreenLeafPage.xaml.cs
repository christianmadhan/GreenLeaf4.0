using System;

using GreenLeaf.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf.Views
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
