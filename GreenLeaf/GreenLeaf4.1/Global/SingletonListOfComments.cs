using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;
using Newtonsoft.Json;

namespace GreenLeaf4._1.Global
{
    public class SingletonListOfComments
    {
        public static ObservableCollection<Comment> ListOfComments;

        private static SingletonListOfComments Instance { get; set; }

        private SingletonListOfComments()
        {
            LoadCommentList();
        }

        public static void LoadCommentList()
        {
            try
            {
                var data = WebApiService.GetDataFromWeb("api/Comments");
                ListOfComments = JsonConvert.DeserializeObject<ObservableCollection<Comment>>(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static SingletonListOfComments GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonListOfComments();
            }
            return Instance;
        }

        public void SetCommentList(ObservableCollection<Comment> listComment)
        {
            ListOfComments = listComment;
        }

        public ObservableCollection<Comment> GetCommentsList()
        {
            return ListOfComments;
        }
    }
}
