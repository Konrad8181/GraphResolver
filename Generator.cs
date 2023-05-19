using MethodTimer;

public class Generator
{
    [Time]
    public List<List<int>> GenerateCities(int maxN = 100000, int maxEdges = 200000)
    {
        var random = new Random();
        var n = random.Next(0,maxN);

        Console.WriteLine($"n={n}");

        var maxElements = maxEdges;

        var cityRoads = new List<List<int>>();
        var elementsCount = 0;

        for (var i = 0; i < n; i++)
        {
            List<int> newRoads;
            if (elementsCount < maxElements)
            {
                newRoads = Enumerable.Range(0, n).Where(x => x != i)
                    .OrderBy(x => random.Next())
                    .Take(random.Next(0, Math.Min(n - 2, maxElements - elementsCount) + 1))
                    .ToList();
                elementsCount += newRoads.Count;
            }
            else
            {
                newRoads = new List<int>();
            }
            cityRoads.Add(newRoads);
        }
        return cityRoads;
    }
}