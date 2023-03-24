using Domain.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infrastructure.Neclines.ViewModels
{
    public class GetNecklineVm
    {
        public Guid Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }

        public IFormFile Photo { get; set; }

        public List<Clothes> Clothes { get; set; } = new List<Clothes>();

    }
}
