using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Models;

namespace GreenLeaf4._1.Services
{
   public static class CommentDataServicecs
    {
        private static readonly SingletonListOfComments Instance = SingletonListOfComments.GetInstance();
        private static IEnumerable<Comment> AllComments()
        {
            return Instance.GetCommentsList();
        }

        public static ObservableCollection<Comment> GetGridCommentsData()
        {
            return new ObservableCollection<Comment>(AllComments());
        }

        public static async Task<IEnumerable<Comment>> GetCommentModelDataAsync()
        {
            await Task.CompletedTask;
            return AllComments();
        }
    }
}
