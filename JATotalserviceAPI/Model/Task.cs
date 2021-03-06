﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer
{
    public class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool isComplete { get; set; }
        public string houseNumber { get; set; }
        public string road { get; set; }
        public string zipcode { get; set; }
        public List<TimeRegistartion> timeRegistrations { get; set; }
        public List<Tuple<Material, int>> materials { get; set; }
        
    }
}
