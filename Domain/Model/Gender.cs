using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Gender:BaseEntity
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Clothes> ClothesGender { get; set; }
    }
}
