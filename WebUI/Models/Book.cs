using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace WebUI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string BookName { get; set; }
    }
    public class SelectdBook
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        
    }
    public class BookView
    {
        
        public string Value { get; set; }
        public string Text { get; set; }

    }
}