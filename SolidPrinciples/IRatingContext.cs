namespace SolidPrinciples;

public interface IRatingContext : ILogger
{
    string LoadPolicyFromFile();
    string LoadPolicyFromUrl();
    Policy GetPolicyFromJsonString(string policyJson);
    Policy GetPolicyFromXmlString(string policyXml);
    Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
    RatingEngine Engine { get; set; }
}