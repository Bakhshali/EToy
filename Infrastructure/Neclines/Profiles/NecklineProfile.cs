using AutoMapper;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Genders.Commands;
using Infrastructure.Genders.ViewModels;
using Infrastructure.Neclines.Commands;
using Infrastructure.Neclines.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Neclines.Profiles
{
    public class NecklineProfile : Profile, IProfileRegister
    {
        public NecklineProfile()
        {
            CreateMap<GetNecklineVm, Neckline>().ReverseMap()
               .ForMember(e => e.Clothes, from => from.MapFrom(q => q.DressNeckline));

            CreateMap<CreateNecklineCommand, Neckline>().ReverseMap();
        }
    }
}
