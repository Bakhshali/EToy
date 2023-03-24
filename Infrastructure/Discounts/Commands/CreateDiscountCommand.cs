using Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Discounts.Commands
{
    public class CreateDiscountCommand : IRequest<OperationResult<Guid>>
    {
        [MaxLength(255)]
        public byte Percent { get; set; }
    }
}
