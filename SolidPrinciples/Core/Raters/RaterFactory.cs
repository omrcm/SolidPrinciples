namespace SolidPrinciples;

public class RaterFactory
{
    private readonly ILogger _logger;

    public RaterFactory(ILogger logger)
    {
        _logger = logger;
    }
    public Rater Create(Policy policy)
    {
        try
        {
            return (Rater)Activator.CreateInstance(
                Type.GetType($"SolidPrinciples.{policy.Type}.Policy"),
                new object[] { _logger });
        }
        catch
        {
            return new UnknownPolicyRater(_logger);
        }
        
    }
}