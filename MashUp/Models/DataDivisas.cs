using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MashUp.Models
{
    public class DataDivisas
    {
        
        public string target { get; set; }
        public int base_amount { get; set; }
        public double converted_amount { get; set; }
        public double exchange_rate { get; set; }
        public int last_updated { get; set; }
    }
}