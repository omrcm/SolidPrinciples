using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SolidPrinciples;

public class JsonPolicySerializer
{
    public Policy GetJsonFromJsonString(string jsonString)
    {
        return JsonConvert.DeserializeObject<Policy>(jsonString, new StringEnumConverter());
    }
}