using Newtonsoft.Json;
using System.Collections.Generic;

namespace Figaro {

    public class JsonBody : Body {

        Dictionary<string,string> jsonValues;
        Dictionary<string,string> JsonValues { get { return jsonValues ?? LoadJsonValues; } }
        Dictionary<string,string> LoadJsonValues { get { return 
            jsonValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(Content)        
        ;}}

        public string Content { get; set; }

        public string ValueOf(string Part, string PartPrefix = "") { return JsonValues[Part]; }
    }
}
