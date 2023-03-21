using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SolidRating;

public class RatingEngine
{
    public decimal Rating { get; set; }

    public ConsoleLogger Logger { get; set; } = new ConsoleLogger();

    public FileSource DataSource { get; set; } = new FileSource();
    public void Rate()
    {
        Logger.Log("Rate Starting...");
        
        Logger.Log("Loading from file...");

        var data = DataSource.GetDataFromSource();

        var policy = JsonConvert.DeserializeObject<Policy>(data, new StringEnumConverter());

        switch (policy.Type)
        {
            case PolicyType.Auto:
                Logger.Log("Rating Auto policy.");
                Logger.Log("Validating policy");
                if (String.IsNullOrEmpty(policy.Make))
                {
                    Logger.Log("Auto policy must specify Make");
                    return;
                }

                if (policy.Make == "BMV")
                {
                    if (policy.Deductible < 500)
                    {
                        Rating = 1000m;
                    }

                    Rating = 900m;
                }
                break;
            case PolicyType.Land:
                Logger.Log("Rating LAND policy.");
                Logger.Log("Validating policy");
                if (policy.BondAmount == 0 || policy.Valuation == 0)
                {
                    Logger.Log("Land policy must specify BondAmount and Valuation");
                    return;
                }

                if (policy.BondAmount < 0.8m * policy.Valuation)
                {
                    Logger.Log("Insufficient bond amount");
                    return;
                }

                Rating = policy.BondAmount * 0.5m;
                break;
            case PolicyType.Life:
                Logger.Log("Rating LIFE policy.");
                Logger.Log("Validating policy");
                if (policy.DateOfBirth == DateTime.MinValue)
                {
                    Logger.Log("Life policy must include Date of Birth.");
                    return;
                }
                if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                {
                    Logger.Log("Centenarians are not eligible for coverage.");
                    return;
                }
                if (policy.Amount == 0)
                {
                    Logger.Log("Life policy must include an Amount.");
                    return;
                }
                int age = DateTime.Today.Year - policy.DateOfBirth.Year;
                if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                    DateTime.Today.Day < policy.DateOfBirth.Day ||
                    DateTime.Today.Month < policy.DateOfBirth.Month)
                {
                    age--;
                }
                decimal baseRate = policy.Amount * age / 200;
                if (policy.IsSmoker)
                {
                    Rating = baseRate * 2;
                    break;
                }
                Rating = baseRate;
                break;
            default:
                Logger.Log("Unknown policy type");
                break;
        }
        
        Logger.Log("Rating complete.");
    }
}