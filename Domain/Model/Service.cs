using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Service:BaseEntity
    {
        [Required,MaxLength(255)]
        public string Name { get; set; }

        public ICollection<PalaceService> ServicesOfPalaces { get; set; }
    }
}
