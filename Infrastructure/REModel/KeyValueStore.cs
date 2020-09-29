using System;
using System.Collections.Generic;
using System.Text;

namespace REModel
{
    public class KeyValueStore
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Parent { get; set; }
        public string Type { get; set; }
    }
}
