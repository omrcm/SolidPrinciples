namespace SolidPrinciples;

public class RaterFactory
{
    public Rater Create(Policy policy, IRatingContext context)
    {
        // using reflaction
        /*
        try
        {
            return (Rater)Activator.CreateInstance(
                Type.GetType($"SolidPrinciples.{policy.Type}.Policy"),
                new object[] {context});
        }
        catch
        {
            return new UnknownPolicyRater(context);
        }
        */

        return policy.Type switch
        {
            PolicyType.Auto => new AutoPolicy(context),
            PolicyType.Land => new LandPolicy(context),
            PolicyType.Life => new LifePolicy(context),
            PolicyType.Flood => new FloodPolicy(context),
            _ => new UnknownPolicyRater(context)
        };
    }
}