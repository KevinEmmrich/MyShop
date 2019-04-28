using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BasketId { get; set; }
        /// <summary>
        /// Points back to the Product table
        /// </summary>
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
