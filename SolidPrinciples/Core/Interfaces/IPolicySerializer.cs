using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SolidPrinciples;

public interface IPolicySerializer
{
    Policy GetPolicyFromString(string policyString);
}