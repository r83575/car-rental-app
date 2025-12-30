using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ScorePerHour { get; set; }
        public int ScorePerDay { get; set; }
        public IFormFile? ImageFile { get; set; }//הקובץ של התמונה
        public string? Image { get; set; }//Base64
        public IFormFile? LogoFile { get; set; }
        public string? Logo { get; set; }

    }
}
