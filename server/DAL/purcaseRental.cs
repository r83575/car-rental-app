using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL
{
    public class PurchaseRental
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public int PurchaseId { get; set; }
        public int Scores { get; set; }
    }
}