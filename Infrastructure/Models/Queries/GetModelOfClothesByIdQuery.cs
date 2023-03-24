using Infrastructure.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models.Queries
{
    public class GetModelOfClothesByIdQuery : IRequest<GetModelOfClothesVm>
    {
        public GetModelOfClothesByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
