using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Stores.Commands
{
    public class CreateStoreCommand : IRequest<OperationResult<Guid>>
    {
        [Required, MaxLength(255)]
        [Remote(controller: "Store", action: "CheckStoreExists", areaName: "Panel")]
        public string Name { get; set; }
    }
}
