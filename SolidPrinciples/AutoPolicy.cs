namespace SolidPrinciples;

public class AutoPolicy : Rater
{
    public AutoPolicy(RatingEngine engine, ConsoleLogger logger): base(engine,logger) { }

    public override void Rate(Policy policy)
    {
        _logger.Log("Rating Auto policy");
        _logger.Log("Validating");

        if (String.IsNullOrEmpty(policy.Make))
        {
            _logger.Log("AutoPolicy must be speciy Make");
            return;
        }

        if (policy.Make == "BMW")
        {
            if (policy.Deductible < 500)
            {
                _engine.Rating = 1000m;
            }

            _engine.Rating = 900m;
        }
    }
    
}