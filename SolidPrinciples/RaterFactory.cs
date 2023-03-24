namespace SolidPrinciples;

public class RaterFactory
{
    public Rater Create(Policy policy, RatingEngine engine)
    {
        /* using reflection 
        try
        {
            return (Rater)Activator.CreateInstance(
                Type.GetType($"SolidPrinciples.{policy.Type}.Policy"),
                new object[] {engine, engine.Logger});
        }
        catch
        {
            return null;
        }
        */

        return policy.Type switch
        {
            PolicyType.Auto => new AutoPolicy(engine, engine.Logger),
            PolicyType.Land => new LandPolicy(engine, engine.Logger),
            PolicyType.Life => new LifePolicy(engine, engine.Logger),
            PolicyType.Flood => new FloodPolicy(engine, engine.Logger),
            _ => new UnknownPolicyRater(engine, engine.Logger)
        };
    }
}