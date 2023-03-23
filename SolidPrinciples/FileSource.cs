namespace SolidPrinciples;

public class FileSource
{
    public string GetDataFromSource()
    {
        return File.ReadAllText("data.json");
    }
}