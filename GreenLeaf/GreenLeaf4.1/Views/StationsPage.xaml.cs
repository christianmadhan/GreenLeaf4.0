using System;
using System.Collections.ObjectModel;
using GreenLeaf4._1.ViewModels;

using Windows.UI.Xaml.Controls;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;

namespace GreenLeaf4._1.Views
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
