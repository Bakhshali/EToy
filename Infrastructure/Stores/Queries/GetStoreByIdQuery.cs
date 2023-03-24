using Infrastructure.Stores.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Stores.Queries
{
    public class GetStoreByIdQuery : IRequest<GetStoreVm>
    {
        public GetStoreByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
