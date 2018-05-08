using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;

namespace GreenLeaf4._1.ViewModels
{
    class UpdatedViewModel : Observable
    {
        private readonly SingletonTask Instances = SingletonTask.GetInstance();
        private string _status;

        public string Status
        {
            get => _status;
        }

        public string Description { get; }
        public int TaskID { get; }

        public UpdatedViewModel()
        {
            _status = Instances.GetStatus();
            Description = Instances.GetDescription();
            TaskID = Instances.GetTaskID();
        }
    }
}
