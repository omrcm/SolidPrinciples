namespace SolidPrinciples;

public class AutoPolicy : Rater
{
    public AutoPolicy(ILogger logger): base(logger) { }

    public override decimal Rate(Policy policy)
    {
        Logger.Log("Rating Auto policy");
        Logger.Log("Validating");

        if (String.IsNullOrEmpty(policy.Make))
        {
            Logger.Log("AutoPolicy must be speciy Make");
            return 0m;
        }

        if (policy.Make == "BMW")
        {
            if (policy.Deductible < 500)
            {
                return 1000m;
            }

            return 900m;
        }

        return 0m;
    }
    
}