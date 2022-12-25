using System;
using System.Collections.Generic;
using System.Text;

namespace Test2222.Models
{
    class ListResourceRes
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Datum> data { get; set; }
        public Support support { get; set; }
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public partial class Datum
        {
            public int id { get; set; }
            public string name { get; set; }
            public int year { get; set; }
            public string color { get; set; }
            public string pantone_value { get; set; }
        }

        public partial class Support
        {
            public string url { get; set; }
            public string text { get; set; }
        }

    }
}
