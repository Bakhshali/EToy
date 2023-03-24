using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Textiles.Commands
{
    public class CreateTextileCommand : IRequest<OperationResult<Guid>>
    {
        [Required, MaxLength(255)]
        public string Name { get; set; }
    }
}
