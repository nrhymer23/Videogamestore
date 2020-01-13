using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
/*
 Course: ACST 3540
Section 01
Name: Noel Rhymer
Professor: Shaw
Assignment: HW8
*/

namespace ShoppingCart.Models
{

    [MetadataType(typeof(CustomerMetadata))]

    public partial class Customer
    {
    }

    public class CustomerMetadata
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Frist Name is Required")]
        [StringLength(30, ErrorMessage ="First Name Cannot be over 30 Characters")]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [StringLength(30, ErrorMessage = "Last Name Cannot be over 30 Characters")]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        [StringLength(50, ErrorMessage = "Street Address Cannot be over 50 Characters")]
        public string StreetAddress { get; set; }

        [StringLength(30, ErrorMessage = "City Cannot be over 30 Characters")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "State Cannot be over 20 Characters")]
        public string State { get; set; }


        [StringLength(10, ErrorMessage = "Zip Cannot be over 10 Characters")]
        public string Zip { get; set; }


        [StringLength(15, ErrorMessage = "Phone Number Cannot be over 15 Characters")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [StringLength(30, ErrorMessage = "Email Cannot be over 30 Characters")]
        [Display(Name = "Email*")]
        public string Email { get; set; }
    }
}