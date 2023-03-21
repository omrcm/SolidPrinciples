using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SolidRating;

public class RatingEngine
{
    public decimal Rating { get; set; }

    public void Rate()
    {
        Console.WriteLine("Rate Starting...");
        
        Console.WriteLine("Loading from file...");

        var data = File.ReadAllText("data.json");

        var policy = JsonConvert.DeserializeObject<Policy>(data, new StringEnumConverter());

        switch (policy.Type)
        {
            case PolicyType.Auto:
                Console.WriteLine("Rating Auto policy.");
                Console.WriteLine("Validating policy");
                if (String.IsNullOrEmpty(policy.Make))
                {
                    Console.WriteLine("Auto policy must specify Make");
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
                Console.WriteLine("Rating LAND policy.");
                Console.WriteLine("Validating policy");
                if (policy.BondAmount == 0 || policy.Valuation == 0)
                {
                    Console.WriteLine("Land policy must specify BondAmount and Valuation");
                    return;
                }

                if (policy.BondAmount < 0.8m * policy.Valuation)
                {
                    Console.WriteLine("Insufficient bond amount");
                    return;
                }

                Rating = policy.BondAmount * 0.5m;
                break;
            case PolicyType.Life:
                Console.WriteLine("Rating LIFE policy.");
                Console.WriteLine("Validating policy");
                if (policy.DateOfBirth == DateTime.MinValue)
                {
                    Console.WriteLine("Life policy must include Date of Birth.");
                    return;
                }
                if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
                {
                    Console.WriteLine("Centenarians are not eligible for coverage.");
                    return;
                }
                if (policy.Amount == 0)
                {
                    Console.WriteLine("Life policy must include an Amount.");
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
                Console.WriteLine("Unknown policy type");
                break;
        }
        
        Console.WriteLine("Rating complete.");
    }
}