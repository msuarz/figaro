using Newtonsoft.Json;
using System.Collections.Generic;

namespace Figaro {

    public class JsonBody : Body {

        Dictionary<string,string> JSONValues { get; set; }

        public JsonBody(string Content) {
            JSONValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(Content);
        }

        public string ValueOf(string Part) { return JSONValues[Part]; }
    }
}
