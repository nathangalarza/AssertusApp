//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssertusApp.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        //[Required]
        //[RegularExpression(@"^\(\d{3}\)\s{0,1}\d{3}-\d{7}$", ErrorMessage = "Enter a valid number")]
        public string Phone { get; set; }
        //[Required]
        //[RegularExpression(@"^\(\d{3}\)\s{0,1}\d{3}-\d{7}$", ErrorMessage = "Enter a valid number")]
        public string Fax { get; set; }
        public string eMail { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public string LastUpdateUserName { get; set; }
    }
}