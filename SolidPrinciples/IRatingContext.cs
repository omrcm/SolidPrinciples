namespace SolidPrinciples;

public interface IRatingContext
{
    void Log(string message);
    string LoadPolicyFromFile();
    string LoadPolicyFromUrl();
    Policy GetPolicyFromJsonString(string policyJson);
    Policy GetPolicyFromXmlString(string policyXml);
    Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
    void UpdateRating(decimal rating);
    RatingEngine Engine { get; set; }
    ConsoleLogger Logger { get; }
}