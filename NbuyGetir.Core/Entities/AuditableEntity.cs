using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Entities
{
    public abstract class AuditableEntity : Entity, IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }
}
