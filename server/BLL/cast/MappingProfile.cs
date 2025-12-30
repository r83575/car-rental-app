using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DTO;

namespace BLL.cast
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(dest=>dest.Image
            ,src=>src.MapFrom(s=>Convert.ToBase64String(ConvertToByte(s.Image))))
                .ForMember(dest => dest.Logo
            , src => src.MapFrom(s => Convert.ToBase64String(ConvertToByte(s.Logo))));
            CreateMap<ProductDTO, Product>();
        }
        public byte[] ConvertToByte(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}       
