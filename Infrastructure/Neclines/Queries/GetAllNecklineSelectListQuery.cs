using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Neclines.Queries
{
    public class GetAllNecklineSelectListQuery : IRequest<SelectList>
    {
        public Guid Id { get; set; }

        public GetAllNecklineSelectListQuery(Guid id)
        {
            Id = id;
        }
    }
}
