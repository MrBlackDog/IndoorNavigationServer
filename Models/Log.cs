﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public double AvgLevel { get; set; }
        public int LocationId { get; set; }
        public virtual LocationRoom LocRomm { get; set; }
    }
}
