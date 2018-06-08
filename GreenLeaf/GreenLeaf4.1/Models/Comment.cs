using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
    /* Inherits the INotifyChanged Property Class
     * This makes sure that the model get updated when we make changes
     * in the view
    */
    public class Comment : Observable
    {

        // Private properties
        private int _commentID;
        private string _description;
        private int _stationID;

        /*Constructer for the class, its important that the properties of the object
         * Is the same as the fields in the database.
        */
        public Comment(int commentID, string description, int stationID)
        {
            _commentID = commentID;
            _description = description;
            _stationID = stationID;
        }

        // Empty constructer for Singleton
        public Comment() { }


       //-----------------------------------------------------------------------------------
       // Get and set Methods
       // On the set method we use the OnPropertyChanged method 
        public int CommentID
        {
            get { return _commentID; }
            set { _commentID = value; OnPropertyChanged(nameof(CommentID)); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public int StationID
        {
            get { return _stationID; }
            set { _stationID = value; OnPropertyChanged(nameof(StationID)); }
        }

    }
}
