using Domain.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Model
{
    public class Neckline:BaseEntity
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

        public ICollection<Clothes> DressNeckline { get; set; }
    }
}
