﻿using System;
using System.Collections.ObjectModel;
using GreenLeaf4._1.Global;
using GreenLeaf4._1.Helpers;
using GreenLeaf4._1.Models;
using GreenLeaf4._1.Services;

namespace GreenLeaf4._1.ViewModels
{
    public class MonitorsViewModel : Observable
    {
        SingletonListOfMonitors Instance = SingletonListOfMonitors.GetInstance();
        public ObservableCollection<Monitor> Source
        {
            get
            {
                return Instance.GetMonitorList();
                
            }
        }
    }
}
