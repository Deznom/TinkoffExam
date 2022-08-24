using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private class Elevator
    {
        public int floor0;
        public int floor1;
        public bool visited;

        public Elevator(int lowerFloor, int upperFloor)
        {
            floor0 = lowerFloor;
            floor1 = upperFloor;
            visited = false;
        }
    }

    private class ElevatorSystem
    {
        public List<Elevator> elevators;

        public ElevatorSystem()
        {
            elevators = new List<Elevator>();
        }

        public void AddElevator(string elevatorString)
        {
            var splitElevatorString = elevatorString.Split(' ');
            elevators.Add(new Elevator(int.Parse(splitElevatorString[0]), int.Parse(splitElevatorString[1])));
        }

        public int FindLongestChain()
        {
            var longestChain = int.MinValue;

            for (var i = 0; i < elevators.Count; i++)
            {
                var dfsResult = ElevatorDFS(elevators, elevators[i], 0);
                
                if (dfsResult > longestChain)
                {
                    longestChain = dfsResult;
                }

                foreach (var elevator in elevators)
                {
                    elevator.visited = false;
                }
            }

            return longestChain;
        }

        private int ElevatorDFS(List<Elevator> elevatorList, Elevator rootElevator, int counter)
        {
            var max = 0;
            var adjacentElevators =
                elevatorList.Where(elevator => elevator.floor0 == rootElevator.floor1 && !elevator.visited);

            counter++;
            rootElevator.visited = true;
            foreach (var elevator in adjacentElevators)
            {
                var dfs = ElevatorDFS(elevatorList, elevator, counter);
                if (dfs > max)
                {
                    max = dfs;
                }
            }

            return counter + max;
        }
    }

    public static void Main(string[] args)
    {
        var elevatorCount = int.Parse(Console.ReadLine());
        var elevatorSystem = new ElevatorSystem();

        for (var i = 0; i < elevatorCount; i++)
        {
            elevatorSystem.AddElevator(Console.ReadLine());
        }

        Console.WriteLine(elevatorSystem.FindLongestChain());
    }
}