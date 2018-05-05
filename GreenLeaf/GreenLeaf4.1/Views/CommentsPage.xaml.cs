using System;

using GreenLeaf4._1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf4._1.Views
{
    public sealed partial class CommentsPage : Page
    {
        public CommentsViewModel ViewModel { get; } = new CommentsViewModel();

        // TODO WTS: Change the grid as appropriate to your app.
        // For help see http://docs.telerik.com/windows-universal/controls/raddatagrid/gettingstarted
        // You may also want to extend the grid to work with the RadDataForm http://docs.telerik.com/windows-universal/controls/raddataform/dataform-gettingstarted
        public CommentsPage()
        {
            InitializeComponent();
        }
    }
}
