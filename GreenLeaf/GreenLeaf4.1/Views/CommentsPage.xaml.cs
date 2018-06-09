using System;

using GreenLeaf4._1.ViewModels;

using Windows.UI.Xaml.Controls;

namespace GreenLeaf4._1.Views
{
    public sealed partial class CommentsPage : Page
    {
        public CommentsViewModel ViewModel { get; } = new CommentsViewModel();

        public CommentsPage()
        {
            InitializeComponent();
        }
    }
}
