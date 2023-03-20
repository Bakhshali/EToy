using Infrastructure.Industrials.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Industrials.Queries
{
    public class GetIndustrialByIdQuery:IRequest<GetIndustrialVm>
    {
        public GetIndustrialByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
