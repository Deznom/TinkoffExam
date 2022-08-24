using System;
using System.Linq;


public class Program
{
    struct Coords
    {
        public int x;
        public int y;
    }

    struct Office
    {
        public Coords lowerLeft;
        public Coords upperRight;
    }

    public static void Main(string[] args)
    {
        var office1 = ParseCoords(Console.ReadLine());
        var office2 = ParseCoords(Console.ReadLine());
        Console.WriteLine(GetTotalArea(office1, office2));
    }

    private static Office ParseCoords(string coordsString)
    {
        var coords = new Coords[2];
        var splitCoords = coordsString.Split(' ');

        coords[0] = new Coords
        {
            x = int.Parse(splitCoords[0]),
            y = int.Parse(splitCoords[1])
        };

        coords[1] = new Coords
        {
            x = int.Parse(splitCoords[2]),
            y = int.Parse(splitCoords[3])
        };

        return new Office
        {
            lowerLeft = coords[0],
            upperRight = coords[1]
        };
    }

    private static int GetTotalArea(Office office0, Office office1)
    {
        var xMaxDelta = Math.Max(
            Math.Max(
                Math.Abs(office0.lowerLeft.x - office1.lowerLeft.x),
                Math.Abs(office0.lowerLeft.x - office1.upperRight.x)),
            Math.Max(
                Math.Abs(office0.upperRight.x - office1.lowerLeft.x),
                Math.Abs(office0.upperRight.x - office1.upperRight.x))
        );

        var yMaxDelta = Math.Max(
            Math.Max(
                Math.Abs(office0.lowerLeft.y - office1.lowerLeft.y),
                Math.Abs(office0.lowerLeft.y - office1.upperRight.y)),
            Math.Max(
                Math.Abs(office0.upperRight.y - office1.lowerLeft.y),
                Math.Abs(office0.upperRight.y - office1.upperRight.y))
        );

        var maxDelta = Math.Max(xMaxDelta, yMaxDelta);

        return maxDelta * maxDelta;
    }
}