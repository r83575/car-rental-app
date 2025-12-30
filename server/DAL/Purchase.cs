using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ScoreBalance { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual User? User { get; set; }
        //[IgnoreDataMember]
        //[JsonIgnore]
        public int PackageId { get; set; }
        //[IgnoreDataMember]
        //[JsonIgnore]
        public virtual Package? Package { get; set; }
        //[IgnoreDataMember]
        //[JsonIgnore]
        //public virtual List<Rental>? Rentals { get; set; }
    }
}
