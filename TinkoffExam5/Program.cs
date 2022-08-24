using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var splitInputString = Console.ReadLine().Split(' ');
        var nameCount = int.Parse(splitInputString[0]);
        var requestCount = int.Parse(splitInputString[1]);
        
        var names = new List<string>();
        var requests = new List<string>();

        for (var i = 0; i < nameCount; i++)
        {
            names.Add(Console.ReadLine());
        }
        
        for (var i = 0; i < requestCount; i++)
        {
            requests.Add(Console.ReadLine());
        }

        for (var i = 0; i < requestCount; i++)
        {
            splitInputString = requests[i].Split(' ');
            
            var order = int.Parse(splitInputString[0]) - 1;
            var prefix = splitInputString[1];

            var foundNames = names.ToList().Where(name => name.StartsWith(prefix)).OrderBy(name => name)
                .ToArray();

            Console.WriteLine(foundNames.Length > order ? names.IndexOf(foundNames[order]) + 1 : -1);
        }
    }
}