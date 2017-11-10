using System;
using System.Collections.Generic;
using System.Text;

namespace eXtensoft.Demo.Model
{
    public class ContentItem
    {
        public string Id { get; set; }

        public List<string> Tags { get; set; }

        public string Display { get; set; }

        public string Text { get; set; }

        public string Mime { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }
    }
}
