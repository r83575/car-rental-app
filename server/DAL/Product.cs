using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ScorePerHour { get; set; }
        public int ScorePerDay { get; set; }
        public string? Image { get; set; }//הנתיב של התמונה בשרת
        public string? Logo { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public virtual List<Rental>? Rentals { get; set; }
    }
}
