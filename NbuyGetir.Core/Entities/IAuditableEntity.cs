using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbuyGetir.Core.Entities
{
    /// <summary>
    /// denetlenebilir entity kimin tarafından updated created yapıldıgı bilgisini tutacağız.
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// entity hangi tarihte ilk eklendi
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// entity hangi tarihte ilk güncellendi
        /// </summary>
        public DateTime UpdatedDate { get; set; }
        /// <summary>
        /// kim tarafından eklendi
        /// </summary>
        public string CreateBy { get; set; }
        /// <summary>
        /// kim tarafından güncellendi.
        /// </summary>
        public string UpdateBy { get; set; }
    }
}
