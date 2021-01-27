using AssertusApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssertusApp.ViewModel
{
    public class MyContactsViewModel
    {     

        public CurrentUser User { get; set; }
        public List<Models.DB.Contact> contacts {get;set;}
    }
}