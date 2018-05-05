using System;
using System.Collections.ObjectModel;

using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;

namespace GreenLeaf4._1.ViewModels
{
    public class CommentsViewModel : Observable
    {
        public ObservableCollection<Comment> Source
        {
            get
            {
                return CommentDataServicecs.GetGridCommentsData();
            }
        }
    }
}
