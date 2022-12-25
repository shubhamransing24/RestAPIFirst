using System;
using System.Collections.Generic;
using System.Text;

namespace Test2222.Models
{
    class GetSingleUserResponse
    {
        public Data data { get; set; }
        public Support support { get; set; }
        public class Data
        {
            public int id { get; set; }
            public string email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string avatar { get; set; }
        }

    
  

        public class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }
    }
}
