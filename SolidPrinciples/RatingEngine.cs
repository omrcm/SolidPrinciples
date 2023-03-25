namespace SolidPrinciples;

public class RatingEngine
{
    public IRatingContext Context { get; set; } = new RatingContext();
    public decimal Rating { get; set; }

    public RatingEngine()
    {
        Context.Engine = this;
    }
    public void Rate()
    {
        Context.Log("Rate Starting...");
        
        Context.Log("Loading from file...");

        string policyJson = Context.LoadPolicyFromFile();
        var policy = Context.GetPolicyFromJsonString(policyJson);
        var rater = Context.CreateRaterForPolicy(policy, Context);
        rater.Rate(policy);
        
        Context.Log("Rating complete.");
    }
}