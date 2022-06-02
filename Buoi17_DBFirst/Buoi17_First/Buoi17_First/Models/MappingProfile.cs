using AutoMapper;
using Buoi17_First.Data;
using Buoi17_First.ViewModels;

namespace Buoi17_First.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Định nghĩa các bộ map
            CreateMap<Product, ProductViewModel>();
            // .ReverseMap(); là map 2 chiều
            // CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, Customer>();
        }
    }
}
