using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.Models
{
    public class Comment : Observable
    {
        private int _commentID;
        private string _description;
        private int _stationID;

        public Comment(int commentID, string description, int stationID)
        {
            _commentID = commentID;
            _description = description;
            _stationID = stationID;
        }

        // Empty constructer for Singleton
        public Comment() { }

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
