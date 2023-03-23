namespace SolidPrinciples;

public class RatingEngine
{
    public decimal Rating { get; set; }
    public ConsoleLogger Logger { get; set; } = new ConsoleLogger();
    public FileSource DataSource { get; set; } = new FileSource();
    public JsonPolicySerializer PolicySerializer { get; set; } = new JsonPolicySerializer();
    public void Rate()
    {
        Logger.Log("Rate Starting...");
        
        Logger.Log("Loading from file...");

        var data = DataSource.GetDataFromSource();

        var policy = PolicySerializer.GetJsonFromJsonString(data);

        var factory = new RaterFactory();

        var rater = factory.Create(policy, this);
        rater.Rate(policy);
        
        Logger.Log("Rating complete.");
    }
}