using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class PalaceImage:BaseEntity
    {
        public string PhotoUrl { get; set; }

        public Palace Palace { get; set; }
        public Guid PalaceId { get; set; }

        public bool? IsMain { get; set; }
    }
}
