using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenLeaf4._1.Models;

namespace GreenLeaf4._1.Global
{
    public class SingletonTask
    {
        public static CTask _Task;

        private static SingletonTask Instance { get; set; }

        private SingletonTask()
        {
            _Task = new CTask();
        }

        public static SingletonTask GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonTask();
            }
            return Instance;
        }

        public void SetTask(CTask task)
        {
            _Task = task;
        }


        public int GetTaskID()
        {
            return _Task.TaskID;
        }

        public string GetDescription()
        {
            return _Task.Description;
        }

        public string GetStatus()
        {
            return _Task.Status;
        }
    }
}
