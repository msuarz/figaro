using fit;
using System;

namespace Figaro {

    public class ResponseBodyFixture : ColumnFixture {
        public Body Body { get; set; }

        public string Content { get { return Body.Content; } }

        public string Part { get; set; }

        public string PartPrefix { get; set; }

        public string Value { get { return Body.ValueOf(Part,PartPrefix); }}

        public bool IsEmpty { get { return String.IsNullOrEmpty(Content); } }
    }
}