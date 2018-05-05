using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using GreenLeaf4._1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf4._1.Views
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
