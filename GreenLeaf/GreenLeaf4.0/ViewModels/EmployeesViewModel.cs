using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GreenLeaf4._0.Helpers;
using GreenLeaf4._0.Models;
using GreenLeaf4._0.Services;

using Microsoft.Toolkit.Uwp.UI.Controls;

namespace GreenLeaf4._0.ViewModels
{
    public class EmployeesViewModel : Observable
    {
        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public EmployeesViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetSampleModelDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
