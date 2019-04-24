using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    /// <summary>
    /// Base model for model that always have a GUID ID field.
    /// </summary>
    public abstract class BaseEntity
    {
        public string Id { get; set; }

        // why not use datetime and then allays set at = DateTime.UtcNow
        public DateTimeOffset CreatedAt { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
        }





    }
}
