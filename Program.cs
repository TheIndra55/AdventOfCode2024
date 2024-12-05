using System.Reflection;

var input = File.ReadAllLines("input.txt");

var type = Assembly.GetCallingAssembly().GetTypes().First(x => x.Name == "Day5");
var day = (IDay)Activator.CreateInstance(type)!;

Console.WriteLine(day.Part1(input));
Console.WriteLine(day.Part2(input));

interface IDay
{
    public object Part1(string[] input);
    public object Part2(string[] input);
}