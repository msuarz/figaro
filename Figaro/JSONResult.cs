using Newtonsoft.Json;
using System.Collections.Generic;
namespace Figaro
{
    class JSONResult
    {
        public static JSONResult GetValueFor(string propertyName)
        {
            return new JSONResult(propertyName);
        }

        string PropertyName { get; set; }

        private JSONResult(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string ContainedIn(string rawJSON)
        {
            var result = string.Empty;
            var jsonValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(rawJSON);
            return jsonValues[PropertyName];
        }

    }
}
