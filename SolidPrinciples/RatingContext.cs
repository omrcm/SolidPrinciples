namespace SolidPrinciples;

public class RatingContext : IRatingContext
{
    public RatingEngine Engine { get; set; }

    public void Log(string message)
    {
        new ConsoleLogger().Log(message);
    }

    public string LoadPolicyFromFile()
    {
        return new FileSource().GetDataFromSource();
    }

    public string LoadPolicyFromUrl()
    {
        throw new NotImplementedException();
    }

    public Policy GetPolicyFromJsonString(string policyJson)
    {
        return new JsonPolicySerializer().GetJsonFromJsonString(policyJson);
    }

    public Policy GetPolicyFromXmlString(string policyXml)
    {
        throw new NotImplementedException();
    }

    public Rater CreateRaterForPolicy(Policy policy, IRatingContext context)
    {
        return new RaterFactory().Create(policy, context);
    }

    public void UpdateRating(decimal rating)
    {
        Engine.Rating = rating;
    }
}