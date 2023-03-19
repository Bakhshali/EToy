using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class PalaceService
    {
        public Palace Palace { get; set; }
        public Service Service { get; set; }

        public int PalaceId { get; set; }
        public int ServiceId { get; set; }
    }
}
