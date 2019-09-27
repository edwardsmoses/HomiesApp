using Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models.Base
{
    public class BaseEntity : AuditInfo, IDeletableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
