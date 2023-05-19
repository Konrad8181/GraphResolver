using MethodTimer;

public class Solution
{
    [Time]
    public bool[] CanReachAllCities(List<List<int>> graph)
    {
        var n = graph.Count;
        var visited = new bool[n];
        var reachableCities = new List<int>();

        Action<int> bfs = null;
        bfs = (start) =>
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int city = queue.Dequeue();
                reachableCities.Add(city);

                foreach (int neighbor in graph[city])
                {
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visited[neighbor] = true;
                    }
                }
            }
        };

        var result = new bool[n];
        for (var i = 0; i < n; i++)
        {
            result[i] = true;
        }

        for (var city = 0; city < n; city++)
        {
            visited = new bool[n];
            bfs(city);
            for (var i = 0; i < n; i++)
            {
                result[i] = result[i] && visited[i];
            }
        }

        return result;
    }
}