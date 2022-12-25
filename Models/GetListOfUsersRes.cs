using System;
using System.Collections.Generic;
using System.Text;

namespace Test2222.Models
{
    class GetListOfUsersRes
    {
    
  
        public long Page { get; set; }
        public long Per_Page { get; set; }
        public long Total { get; set; }
        public long Total_Pages { get; set; }
        public List<Datum>? Data { get; set; }
        public Support Support { get; set; }
    }

    public class Datum
    {
    
        public long Id { get; set; }
        public string Email { get; set; }
        
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public Uri Avatar { get; set; }
    }

    public class Support
    {
        public Uri Url { get; set; }
        public string Text { get; set; }
    }
}
