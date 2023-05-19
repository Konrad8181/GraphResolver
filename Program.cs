using System.Text;

var generator = new Generator();
var solution = new Solution();
var graphReader = new GraphReader();

// Direct definition
//var cities = new List<List<int>>()
//{
//    new (){ 1, 2 },
//    new (){ 4 },
//    new (){ 1 },
//    new (){ 2,5 },
//    new (){ 2 },
//    new (){ 3 }
//};

// Read from file
var cities = graphReader.ReadDotFile(args[0]);

// Generating
//var cities = generator.GenerateCities();

var res =  solution.CanReachAllCities(cities);
var sb = new StringBuilder();
for (var i = 0; i < res.Length; ++i)
{
    if (res[i])
    {
        sb.Append(i);
        sb.Append(',');
    }
}
if (sb.Length > 0)
{
    sb.Remove(sb.Length - 1, 1);
}
Console.WriteLine(sb.ToString());