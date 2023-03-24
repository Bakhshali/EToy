using AutoMapper;
using Domain.Model;
using Infrastructure.Discounts.Commands;
using Infrastructure.Discounts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Discounts.Profiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<GetDiscountVm, Discount>().ReverseMap()
            .ForMember(s => s.Clothes, from => from.MapFrom(q => q.ClothesDiscount));
            CreateMap<CreateDiscountCommand, Discount>().ReverseMap();
        }
    }
}
