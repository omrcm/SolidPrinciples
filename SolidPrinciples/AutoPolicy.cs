namespace SolidPrinciples;

public class AutoPolicy : Rater
{
    public AutoPolicy(IRatingUpdater ratingUpdater): base(ratingUpdater) { }

    public override void Rate(Policy policy)
    {
        Logger.Log("Rating Auto policy");
        Logger.Log("Validating");

        if (String.IsNullOrEmpty(policy.Make))
        {
            Logger.Log("AutoPolicy must be speciy Make");
            return;
        }

        if (policy.Make != "BMW") return;
        if (policy.Deductible < 500)
        {
            _ratingUpdater.UpdateRating(1000m);
            return;
        }

        _ratingUpdater.UpdateRating(900m);
    }
    
}