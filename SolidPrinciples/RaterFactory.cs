namespace SolidPrinciples;

public class RaterFactory
{
    public Rater Create(Policy policy, RatingEngine engine)
    {
        switch (policy.Type)
        {
            case PolicyType.Auto:
                return new AutoPolicy(engine, engine.Logger);
            case PolicyType.Land:
                return new LandPolicy(engine, engine.Logger);
            case PolicyType.Life:
                return new LifePolicy(engine, engine.Logger);
            case PolicyType.Flood:
                return new FloodPolicy(engine, engine.Logger);
            default:
                return new UnknownPolicyRater(engine, engine.Logger);
        }
    }
}