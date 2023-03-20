using Infrastructure.Genders.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Genders.Queries
{
    public class GetGenderByIdQuery:IRequest<GetGenderVm>
    {
        public Guid Id { get; set; }

        public GetGenderByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
