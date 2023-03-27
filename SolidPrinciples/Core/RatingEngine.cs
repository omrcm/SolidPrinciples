namespace SolidPrinciples;

public class RatingEngine
{
    private readonly ILogger _logger;
    private readonly IPolicySource _policySource;
    private readonly IPolicySerializer _policySerializer;
    private readonly RaterFactory _raterFactory;
    public decimal Rating { get; set; }

    public RatingEngine(ILogger logger, IPolicySource policySource, IPolicySerializer policySerializer, RaterFactory raterFactory)
    {
        _logger = logger;
        _policySource = policySource;
        _policySerializer = policySerializer;
        _raterFactory = raterFactory;
    }
    public void Rate()
    {
        _logger.Log("Rate Starting...");
        
        _logger.Log("Loading from file...");

        var policyJson = _policySource.GetDataFromSource();
        var policy = _policySerializer.GetPolicyFromString(policyJson);
        var rater = _raterFactory.Create(policy);
        rater.Rate(policy);
        
        _logger.Log("Rating complete.");
    }
}