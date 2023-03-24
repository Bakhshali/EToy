using AutoMapper;
using Domain.Model;
using Infrastructure.Models.Commands;
using Infrastructure.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.Profiles
{
    public class ModelOfClothesProfile : Profile
    {
        public ModelOfClothesProfile()
        {
            CreateMap<GetModelOfClothesVm, ModelOfClothes>().ReverseMap()
            .ForMember(s => s.Clothes, from => from.MapFrom(q => q.ClothesModel));
            CreateMap<CreateModelOfCloothesCommand, ModelOfClothes>().ReverseMap();
        }
    }
}
