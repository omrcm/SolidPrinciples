namespace SolidPrinciples;

public class AutoPolicy : Rater
{
    public AutoPolicy(IRatingContext context): base(context) { }

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
                _context.UpdateRating(1000m);
            }

            _context.UpdateRating(900m);
        }
    }
    
}