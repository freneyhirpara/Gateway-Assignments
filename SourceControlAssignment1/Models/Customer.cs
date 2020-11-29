using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MvcCustomValidationAttribute_Demo.CustomValidation;

namespace HelloMVC.Models
{
    public class Customer
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Confirm Email is Required")]
        [DataType(DataType.EmailAddress)]
        
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Email Not Matched")]
        public string ConfirmEmail { get; set; }


        
        [Required(ErrorMessage = "Age is Required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        public int Age { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [CustomPurchaseDate(ErrorMessage="Purchase Date should be less than Today's Date.")]
        public DateTime PurchaseDate { get; set; }

        

        [FileExtensions(Extensions = ". jpg,. png,. gif")]
        public string FileName { get; set; }

        [CreditCard(ErrorMessage = "Please enter a valid credit card number")]
        public string CreditCardNumber { get; set; }



    }
}