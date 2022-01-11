using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shopify.Models
{
    public class OrderModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is Required")]
        public string Name { get; set; }



        [Required(ErrorMessage = "{0} is Required")]
        [StringLength(200, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 20)]
        public string Description { get; set; }


        [Required(ErrorMessage = "{0} is Required")]
        [Range(typeof(decimal), "1", "79228162514264337593543950335", ErrorMessage = "{0} must be 1.")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "{0} is Required")]
        [Range(typeof(decimal), "1", "999999", ErrorMessage = "{0} must be 1.")]
        public decimal Quantity { get; set; }


        public string ImageName { get; set; }

        [Required(ErrorMessage = "{0} is Required")]
        [NotMapped]
        public IFormFile Picture { get; set; }
        [NotMapped]
        public decimal Total => Quantity * Price;
        
        
    }

    public class JRuntime
    {
        public string JavascriptToRun { get; set; }
    }
}

