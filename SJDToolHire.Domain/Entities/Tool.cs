using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SJDToolHire.Domain.Entities
{
    public class Tool
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int ProductID { get; set; }

        [Required(ErrorMessage="Please enter a Tool Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a Tool Description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid Tool Rate")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Please enter a Tool Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please enter a Tool Image File Name")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter a Tool Weight")]
        public string Weight { get; set; }

        [Required(ErrorMessage = "Please enter a Tool Power")]
        public string Power { get; set; }
    }
}
