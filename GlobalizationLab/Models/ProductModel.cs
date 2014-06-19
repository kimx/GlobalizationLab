using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalizationLab.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            this.IsOrder = true;
        }
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        //  [DataType(DataType.DateTime)]
        public DateTime CreateDateTime { get; set; }

        public DateTime? CreateDateTimeNullable { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessageResourceName = "數值不對", ErrorMessageResourceType = typeof(Resources.Resources))]

        //  [Range(double.MinValue, double.MaxValue, ErrorMessageResourceName = "數值不對", ErrorMessageResourceType = typeof(Resources.Resources))]
        public double Price { get; set; }

        [Required(ErrorMessageResourceName = "數值不對", ErrorMessageResourceType = typeof(Resources.Resources))]
        //  [Range(typeof(decimal), "-79228162514264337593543950335", "79228162514264337593543950335", ErrorMessageResourceName = "數值不對", ErrorMessageResourceType = typeof(Resources.Resources))]
        public decimal PricedDecmial { get; set; }


        public string PriceString
        {
            get
            {
                return this.Price.ToString("N");
            }
        }
        //  [Required(ErrorMessageResourceName = "PropertyValueRequired")]
        public int Qty { get; set; }

        [Required()]
        public bool IsOrder { get; set; }

    }
}