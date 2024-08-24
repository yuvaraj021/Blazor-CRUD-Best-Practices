using AutoMapper;
using BlazorCRUD.Application.DTOs;
using BlazorCRUD.Domain.Entities;

namespace BlazorCRUD.Application.Mapper
{
    public class DataMapper:Profile
    {
        public DataMapper() 
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }

    }
}
