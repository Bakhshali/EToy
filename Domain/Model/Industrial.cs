using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Industrial:BaseEntity
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Clothes> ClothesIndustrial { get; set; }
    }
}
