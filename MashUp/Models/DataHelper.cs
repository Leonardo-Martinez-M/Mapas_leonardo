using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using static MashUp.Models.Location;

namespace MashUp.Models
{
    public partial class Location
    {

        public long place_id { get; set; }


        public string lat { get; set; }


        public string lon { get; set; }


        public string addresstype { get; set; }

        public string name { get; set; }

        public string display_name { get; set; }

        public List<Location> Results { get; set; }
    }


}