using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class PalaceService
    {
        public Palace Palace { get; set; }
        public Service Service { get; set; }

        public Guid PalaceId { get; set; }
        public Guid ServiceId { get; set; }
    }
}
