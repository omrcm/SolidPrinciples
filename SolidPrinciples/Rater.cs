namespace SolidPrinciples;

public abstract class Rater
{
    protected readonly IRatingUpdater _ratingUpdater;
    protected ILogger Logger { get; set; } = new ConsoleLogger();

    protected Rater(IRatingUpdater ratingUpdater)
    {
        _ratingUpdater = ratingUpdater;
    }

    public abstract void Rate(Policy policy);
}