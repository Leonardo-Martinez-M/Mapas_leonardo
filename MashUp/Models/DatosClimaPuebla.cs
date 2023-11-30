using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using static MashUp.Models.Temperatures;

namespace MashUp.Models
{

    public partial class Temperatures
    {
        public Coord Coord { get; set; }

        public Weather[] Weather { get; set; }

        public string Base { get; set; }

        public Main Main { get; set; }

        public long Visibility { get; set; }

        public Wind Wind { get; set; }

        public Clouds Clouds { get; set; }

        public long Dt { get; set; }

    
        public Sys Sys { get; set; }

        public long Timezone { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public long Cod { get; set; }
    }

    public partial class Clouds
    {
        public long All { get; set; }
    }

    public partial class Coord
    {
        public long Lon { get; set; }

        public double Lat { get; set; }
    }

    public partial class Main
    {
        public double Temp { get; set; }

        public double FeelsLike { get; set; }

        public double temp_min { get; set; }

        
        public double temp_max { get; set; }

        

        public long Humidity { get; set; }

        
        public long SeaLevel { get; set; }

        public long GrndLevel { get; set; }
    }

    public partial class Sys
    {

        public string Country { get; set; }


        public long Sunrise { get; set; }


        public long Sunset { get; set; }
    }

    public partial class Weather
    {
        public long Id { get; set; }

        public string Main { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
    }

    public partial class Wind
    {
        public double Speed { get; set; }

        public long Deg { get; set; }

        public double Gust { get; set; }
    }

}