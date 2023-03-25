namespace SolidPrinciples;

public class FloodPolicy : Rater
{
    public FloodPolicy(IRatingContext context) : base(context)
    {
    }

    public override void Rate(Policy policy)
    {
        _logger.Log("Rating Flood policy");
        _logger.Log("Validating policy");

        if (policy.BondAmount == 0 || policy.Valuation == 0)
        {
            _logger.Log("Flood policy must specify Bond Amount and Valuation!");
            return;
        }

        if (policy.BondAmount < 0.8m * policy.Valuation)
        {
            _logger.Log("Insufficient bound amount");
            return;
        }

        decimal multiple = 2.0m;
        if (policy.ElevationAboveSeaLevelFeet < 100)
        {
            multiple = 1.5m;
        }
        else if (policy.ElevationAboveSeaLevelFeet < 1000)
        {
            multiple = 1.0m;
        }

        _context.UpdateRating(policy.BondAmount * 0.5m * multiple);
    }
}