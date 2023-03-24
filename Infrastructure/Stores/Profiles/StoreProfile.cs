using AutoMapper;
using Domain.Model;
using Infrastructure.Stores.Commands;
using Infrastructure.Stores.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Stores.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<GetStoreVm, Store>().ReverseMap()
            .ForMember(s => s.Clothes, from => from.MapFrom(q => q.ClothesStore));
            CreateMap<CreateStoreCommand, Store>().ReverseMap();
        }
    }
}
