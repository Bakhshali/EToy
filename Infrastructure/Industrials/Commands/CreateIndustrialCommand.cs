using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Industrials.Commands
{
    public class CreateIndustrialCommand:IRequest<OperationResult<int>>
    {
        [Required,MaxLength(50)]
        [Remote(controller: "Industrials", action: "CheckGenderExists", areaName: "Panel")]
        public string Name { get; set; }

    }
}
