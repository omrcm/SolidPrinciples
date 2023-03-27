namespace SolidPrinciples;

public class FloodPolicy : Rater
{
    public FloodPolicy(ILogger logger) : base(logger)
    {
    }

    public override decimal Rate(Policy policy)
    {
        Logger.Log("Rating Flood policy");
        Logger.Log("Validating policy");

        if (policy.BondAmount == 0 || policy.Valuation == 0)
        {
            Logger.Log("Flood policy must specify Bond Amount and Valuation!");
            return 0m;
        }

        if (policy.BondAmount < 0.8m * policy.Valuation)
        {
            Logger.Log("Insufficient bound amount");
            return 0m;
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

        return policy.BondAmount * 0.5m * multiple;
    }
}