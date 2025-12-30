using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    [Index(nameof(Tz), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [Required]
        public int Tz { get; set; }
        [MaxLength(8)]
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual List<Purchase>? Purchases { get; set; }
    }
}
