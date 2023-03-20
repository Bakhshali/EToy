using Infrastructure.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Genders.Commands
{
    public class CreateGenderCommand:IRequest<OperationResult<int>>
    {
        [MaxLength(50), Required]
        [Remote(controller: "Genders", action: "CheckGenderExists", areaName: "Panel")]
        public string Name { get; set; }
    }
}
