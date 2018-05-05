﻿using System;

using GreenLeaf.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf.Views
{
    public sealed partial class MonitorsPage : Page
    {
        public MonitorsViewModel ViewModel { get; } = new MonitorsViewModel();

        // TODO WTS: Change the grid as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public MonitorsPage()
        {
            InitializeComponent();
        }
    }
}
