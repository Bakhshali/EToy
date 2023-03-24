using Infrastructure.Common;
using Infrastructure.Neclines.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Neclines.Commands
{
    public class CreateNecklineCommand:IRequest<OperationResult<int>>
    {
        [MaxLength(100), Required]
        [Remote(controller: "Genders", action: "CheckGenderExists", areaName: "Panel")]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
