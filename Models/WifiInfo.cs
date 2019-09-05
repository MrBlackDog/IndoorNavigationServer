using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WifiInfo
    {
        public string SSID { get; set; }
        [Key]
        public string BSSID { get; set; }
        public string AvgLevel { get; set; }
      //  public int NumberOfMentions { get; set; } 
    }
}
