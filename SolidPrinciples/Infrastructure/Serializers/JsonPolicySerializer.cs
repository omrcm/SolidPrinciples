using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SolidPrinciples;

public class JsonPolicySerializer : IPolicySerializer
{
    public Policy GetPolicyFromString(string policyString)
    {
        return JsonConvert.DeserializeObject<Policy>(policyString, new StringEnumConverter());
    }
}