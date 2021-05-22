using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models.Entity;

namespace Library.Models.Classes
{
    public class Class1
    {
        public IEnumerable<BOOK> book { get; set; }
        public IEnumerable<ABOUT_US> about {get; set;}
     
    }
}