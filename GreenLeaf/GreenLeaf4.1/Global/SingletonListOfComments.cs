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
        /* Global List of Comments. This class is accessable in our whole application and may only be set once
         * but called as many times as we want. This also why it may seems slow when we navigate between pages
         * because we are calling and retrieving data from our web api which is getting the data from a database
         * on Azure.
         */
        public static ObservableCollection<Comment> ListOfComments;

        private static SingletonListOfComments Instance { get; set; }

        private SingletonListOfComments()
        {
            LoadCommentList();
        }

        public static void LoadCommentList()
        {
            /* We call the Web api service class in our contructer because we want our data immediatly.
             * The data needs to be deserialize so that it can be displayed in the observablecollection.
             */
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

        // Set and get methods for the singleton list.
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
