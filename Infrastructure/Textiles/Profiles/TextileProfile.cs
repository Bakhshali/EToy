using AutoMapper;
using Domain.Model;
using Infrastructure.Textiles.Commands;
using Infrastructure.Textiles.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Textiles.Profiles
{
    public class TextileProfile : Profile
    {
        public TextileProfile()
        {
            CreateMap<GetTextileVm, Textile>().ReverseMap()
            .ForMember(s => s.Clothes, from => from.MapFrom(q => q.ClothesTextile));
            CreateMap<CreateTextileCommand, Textile>().ReverseMap();
        }
    }
}
