using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace eXtensoft.Demo.Model
{
    [DataContract]
    [Serializable]
    public class ContentItem
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public List<string> Tags { get; set; }
        [DataMember]
        public string Display { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Mime { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
    }
}
