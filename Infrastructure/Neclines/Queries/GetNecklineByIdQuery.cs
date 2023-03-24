using Infrastructure.Neclines.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Neclines.Queries
{
    public class GetNecklineByIdQuery:IRequest<GetNecklineVm>
    {
        public GetNecklineByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
