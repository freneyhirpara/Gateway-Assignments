using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.Models
{
    public class Product : BaseEntity
    {
        
        [StringLength(20)]
        [Required(ErrorMessage = "Product Name is Required")]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Description is Required.")]
        public string Description { get; set; }

        [Range(0,100000)]
        [Required(ErrorMessage = "Price is Required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "category is Required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }

        [FileExtensions(Extensions = ". jpg,. png,. gif")]
        public string Image { get; set; }

        
    }
}
