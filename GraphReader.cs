using System.Text.RegularExpressions;

public class GraphReader
{
    public List<List<int>> ReadDotFile(string filePath)
    {
        var data = File.ReadAllText(filePath);

        var cityMatches = Regex.Matches(data, @"(\d+);");
        var cities = cityMatches.Cast<Match>().Select(m => int.Parse(m.Groups[1].Value)).ToList();
        var n = cities.Max() + 1;

        var graph = new List<List<int>>();
        for (var i = 0; i < n; i++)
        {
            graph.Add(new List<int>());
        }

        var connectionMatches = Regex.Matches(data, @"(\d+) -> (\d+);");
        foreach (Match match in connectionMatches)
        {
            var src = int.Parse(match.Groups[1].Value);
            var dest = int.Parse(match.Groups[2].Value);
            graph[src].Add(dest);
        }

        return graph;
    }
}