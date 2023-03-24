using AutoMapper;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Genders.Commands;
using Infrastructure.Genders.ViewModels;
using Infrastructure.Industrials.Commands;
using Infrastructure.Industrials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Industrials.Profiles
{
    public class IndustrialProfile:Profile, IProfileRegister
    {
        public IndustrialProfile()
        {
            CreateMap<GetIndustrialVm, Industrial>().ReverseMap()
                .ForMember(e => e.Clothes, from => from.MapFrom(q => q.ClothesIndustrial));

            CreateMap<CreateIndustrialCommand, Industrial>().ReverseMap();
        }
    }
}
