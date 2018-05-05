using System;

using GreenLeaf.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GreenLeaf.Views
{
    public sealed partial class EmployeesDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(EmployeesDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

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
