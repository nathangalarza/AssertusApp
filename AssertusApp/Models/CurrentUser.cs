using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssertusApp.Models
{
    public class CurrentUser
    {
        [Required]
        public string userName { get; set; }

        public DateTime dateLoggin { get; set; }

    }
}