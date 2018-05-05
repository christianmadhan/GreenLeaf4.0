using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using GreenLeaf.Helpers;
using GreenLeaf.Models;
using GreenLeaf.Services;

using Microsoft.Toolkit.Uwp.UI.Controls;

namespace GreenLeaf.ViewModels
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
