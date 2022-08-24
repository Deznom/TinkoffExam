using System;

public class Program
{
    public static void Main(string[] args)
    {
        var splitInputString = Console.ReadLine().Split(' ');
        var domainCount = int.Parse(splitInputString[0]);
        var clientCount = int.Parse(splitInputString[1]);
        var domains = new string[domainCount];
        var searchStrings = new string[clientCount];

        for (var i = 0; i < domainCount; i++)
        {
            domains[i] = Console.ReadLine();
        }

        for (var i = 0; i < clientCount; i++)
        {
            searchStrings[i] = Console.ReadLine();
        }

        foreach (var searchString in searchStrings)
        {
            var result = 0;
            var splitSearchString = searchString.Split(' ');
            
            foreach (var domain in domains)
            {
                if (domain.StartsWith(splitSearchString[0]) && domain.EndsWith(splitSearchString[1]))
                {
                    result++;
                }
            }
            
            Console.WriteLine(result);
        }
    }
}