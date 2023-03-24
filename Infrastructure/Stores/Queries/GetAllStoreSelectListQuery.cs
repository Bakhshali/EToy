using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Stores.Queries
{
    public class GetAllStoreSelectListQuery : IRequest<SelectList>
    {
        public GetAllStoreSelectListQuery(Guid id)
        {
            id = Id;
        }
        public Guid Id { get; set; }
    }
}
