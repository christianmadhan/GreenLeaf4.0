using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using GreenLeaf4._1.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Views
{
    public sealed partial class EmployeesDetailControl : UserControl
    {
        private CTask _selected;
        public ObservableCollection<CTask> TaskSample = new ObservableCollection<CTask>();
        private readonly SingletonListOfTasks singletonTask = SingletonListOfTasks.GetInstance();
        private readonly SingletonEmployee singleEmp = SingletonEmployee.GetInstance();
        private readonly SingletonTask singleTask = SingletonTask.GetInstance();

        public event PropertyChangedEventHandler PropertyChanged;

        public CTask Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public Employee MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as Employee; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem",
            typeof(Employee), typeof(EmployeesDetailControl),
            new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public EmployeesDetailControl()
        {
            InitializeComponent();
            LoadEmployeesTaskList();      

        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as EmployeesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }

        public void LoadEmployeesTaskList()
        {
            foreach (var tasks in singletonTask.GetTaskList())
            {
                if (tasks.EmpID == singleEmp.GetEmployeeID())
                {
                    TaskSample.Add(tasks);
                }
            }
        }

        private async void GoToUpDateStatusPage(object sender, RoutedEventArgs e)
        {
            singleTask.SetTask(Selected);
            if (Selected == null)
            {
                MessageDialog msg = new MessageDialog("You have to pick a Task");
                await msg.ShowAsync();
            }
            else
            {
                CoreApplicationView newView = CoreApplication.CreateNewView();
                int newViewId = 0;
                await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    Frame frame = new Frame();
                    frame.Navigate(typeof(UpdateStatus), null);
                    Window.Current.Content = frame;
                    // You have to activate the window in order to show it later.
                    Window.Current.Activate();

                    newViewId = ApplicationView.GetForCurrentView().Id;
                });
                bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
            }
        }
        private void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
