using Newtonsoft.Json;
using System.Collections.Generic;
namespace Figaro
{
    class JSONResult
    {
        static JSONResult Instance { get; set; } 

        public static JSONResult ContainedIn(string rawJSON)
        {
            if (Instance == null) Instance = new JSONResult(rawJSON);
            return Instance;
        }

        Dictionary<string,string> JSONValues { get; set; }

        private JSONResult(string rawJSON)
        {
            JSONValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawJSON);
        }

        public string GetValueFor(string propertyName)
        {
            return JSONValues[propertyName];
        }

    }
}
