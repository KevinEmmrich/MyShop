using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        //private string _id;
        private string _category;

        //public string Id    --- Id is in BaseEntity
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        ///////////////////   Methods  Below  /////////////////////////

        //public ProductCategory()    --- Constructor is in BaseEntity
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}




    }
}
