using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
