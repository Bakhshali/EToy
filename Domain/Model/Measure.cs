using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Measure:BaseEntity
    {
        [Required,MaxLength(255)]
        public string Name { get; set; }

        public ICollection<PalaceMeasure> MeasuresOfPalaces { get; set; }

    }
}
