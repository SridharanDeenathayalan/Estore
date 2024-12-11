using AutoMapper;
using Estore.Model.DTOs;

namespace Estore.Model.Config
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {              //Source      //destination
            CreateMap<ProductDTO, Product>().ForMember(p=>p.PictureUrl,opt=>opt.Ignore());
        }
    }
}
