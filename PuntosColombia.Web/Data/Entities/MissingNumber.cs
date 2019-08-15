using System;
using System.ComponentModel.DataAnnotations;

namespace PuntosColombia.Web.Data.Entities
{
    public class MissingNumber
    {
        public int MissingNumberId { get; set; }

        [Display(Name = "Quantity List A")]
        [Range(1, Int32.MaxValue, ErrorMessage = "the quantity cannot be negative or zero")]
        [Required]
        public int QuantityListA { get; set; }

        [Display(Name = "List A")]
        [Required]
        public string ListA { get; set; }

        [Display(Name = "Quantity List B")]
        [Range(1, Int32.MaxValue, ErrorMessage = "the quantity cannot be negative or zero")]
        [Required]
        public int QuantityListB { get; set; }

        [Display(Name = "List B")]
        [Required]
        public string ListB { get; set; }

        [Display(Name = "Missing Numbers")]
        public string ListResult { get; set; }
    }
}
