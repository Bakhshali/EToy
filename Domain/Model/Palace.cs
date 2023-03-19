using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class Palace:BaseEntity
    {
        [Required,MaxLength(255)]
        public string Name { get; set; }

        public int MinGuest { get; set; }

        public int MaxGuest { get; set; }

        [Required,MaxLength(255)]
        public string Address { get; set; }

        [Required]
        public string About { get; set; }

        [Required,MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        public string Map { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public ICollection<PalaceMeasure> MeasuresOfPalaces { get; set; }
        public ICollection<PalaceService> ServicesOfPalaces { get; set; }
    }
}
