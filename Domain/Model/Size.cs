using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Size : BaseEntity
    {
        [Required,MaxLength(20)]
        public string Number { get; set; }

        public ICollection<ClothesSize> ClothesSize { get; set; }

    }
}
