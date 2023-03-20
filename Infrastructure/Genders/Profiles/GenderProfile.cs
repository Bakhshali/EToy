using AutoMapper;
using Domain.Model;
using Infrastructure.ClothesCategories.Commands;
using Infrastructure.ClothesCategories.ViewModels;
using Infrastructure.Genders.Commands;
using Infrastructure.Genders.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Genders.Profiles
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<GetGenderVm, Gender>().ReverseMap()
                .ForMember(e => e.Clothes, from => from.MapFrom(q => q.ClothesGender));

            CreateMap<CreateGenderCommand, Gender>().ReverseMap();
        }
    }
}
