using System;

using GreenLeaf4._1.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GreenLeaf4._1.Views
{
    public sealed partial class EmployeesDetailControl : UserControl
    {
        public Employee MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Employee; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(Employee), typeof(EmployeesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public EmployeesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as EmployeesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
