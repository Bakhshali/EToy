using AutoMapper;
using Domain.Model;
using Infrastructure.ClothesCategories.Commands;
using Infrastructure.ClothesCategories.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ClothesCategories.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<GetCategoryVm, CategoryOfClothes>().ReverseMap()
                .ForMember(e => e.Clothes, from => from.MapFrom(q => q.ClothesCategory));

            CreateMap<CreateCategoryCommand, CategoryOfClothes>().ReverseMap();
        }
    }
}
