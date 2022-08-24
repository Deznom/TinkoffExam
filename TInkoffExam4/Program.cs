using System;
using System.Collections.Generic;

internal class Program
{
    public static void Main(string[] args)
    {
        var variables = new Dictionary<string, int>();
        var variablesStack = new Stack<Dictionary<string, int>>();
        var input = new List<string>();

        string line;
        while ((line = Console.ReadLine()) != null && line != "")
        {
            input.Add(line);
        }

        foreach (var expression in input)
        {
            if (expression.Equals("{"))
            {
                variablesStack.Push(new Dictionary<string, int>(variables));
            }

            if (expression.Equals("}"))
            {
                variables = variablesStack.Pop();
            }

            if (expression.Length <= 1)
            {
                continue;
            }

            var splitExp = expression.Split('=');

            if (!variables.ContainsKey(splitExp[0]))
            {
                variables.Add(splitExp[0], 0);
            }

            if (int.TryParse(splitExp[1], out var parsedResult))
            {
                variables[splitExp[0]] = parsedResult;
            }
            else
            {
                if (!variables.ContainsKey(splitExp[1]))
                {
                    variables.Add(splitExp[1], 0);
                }

                variables[splitExp[0]] = variables[splitExp[1]];
                Console.WriteLine(variables[splitExp[0]]);
            }
        }
    }
}