using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Textiles.Queries
{
    public class GetTextileSelectListQuery : IRequest<SelectList>
    {
        public GetTextileSelectListQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
