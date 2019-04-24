using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProductCategory
    {
        private string _id;
        private string _category;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        ///////////////////   Methods  Below  /////////////////////////

        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }


    

    }
}
