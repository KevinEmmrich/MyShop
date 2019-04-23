using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Product
    {
        private string _id;
        private string _name;
        private string _description;
        private decimal _price;
        private string _category;
        private string _image;


        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [StringLength(20)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [Range(0,1000)]
        [DisplayName("Product Name")]
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }


        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }


        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }


    }
}
