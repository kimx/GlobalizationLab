using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlobalizationLab.Models
{
    public class DateModel
    {


        [Display(Name = "MyName")]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

       

    }
}