using System;
using System.Linq;

internal class Program
{
    public static void Main(string[] args)
    {
        var dayCount = int.Parse(Console.ReadLine());
        int[] sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(CalculateMaxSumInSequence(sequence));
    }

    private static int CalculateMaxSumInSequence(int[] sequence)
    {
        var max = CalculateSequenceSum(sequence);

        for (var i = 0; i < sequence.Length - 1; i++)
        {
            var sum = CalculateSequenceSum(FlipDaysInSequence(sequence, i));
            if (max < sum)
            {
                max = sum;
            }
        }

        return max;
    }

    private static int CalculateSequenceSum(int[] sequence)
    {
        var result = 0;

        for (var i = 0; i < sequence.Length; i++)
        {
            if (i % 2 == 0)
            {
                result += sequence[i];
            }
            else
            {
                result -= sequence[i];
            }
        }

        return result;
    }

    private static int[] FlipDaysInSequence(int[] sequence, int day)
    {
        (sequence[day], sequence[day + 1]) = (sequence[day + 1], sequence[day]);
        return sequence;
    }
}