namespace SolidPrinciples;

public class FilePolicySource : IPolicySource
{
    public string GetDataFromSource()
    {
        return File.ReadAllText("data.json");
    } 
}