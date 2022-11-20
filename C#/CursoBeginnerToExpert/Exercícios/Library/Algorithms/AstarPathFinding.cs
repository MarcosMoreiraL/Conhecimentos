using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Algorithms
{
    public class AstarPathFinding
    {
        public class Location
        {
            public int x, y, score1, score2, score3;
            public Location parent;
        }

        private string[] map;

        public AstarPathFinding(string[] map)
        {
            this.map = map;
        }

        public void SetMap(string[] map)
        {
            this.map = map;
        }

        public void Execute(Location startLocation, Location targetLocation)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            foreach (var line in map)
                Console.WriteLine(line);

            Location current = null, start = startLocation;
        }

        public void Execute(int xStart, int yStart, int xTarget, int yTarget)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            foreach (var line in map)
                Console.WriteLine(line);

            Location current = null, start = new Location { x = xStart, y = yStart}, target = new Location { x = xTarget, y = yTarget};
            List<Location> openList = new List<Location>();
            List<Location> closedList = new List<Location>();
            int spot = 0;

            openList.Add(start);

            while(openList.Count > 0)
            {
                int min = openList.Min(i => i.score1);
                current = openList.First(i => i.score1 == min);

                closedList.Add(current);

                Console.SetCursorPosition(current.x, current.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine('.');
                Console.SetCursorPosition(current.x, current.y);

                System.Threading.Thread.Sleep(200);
                openList.Remove(current);

                if (closedList.FirstOrDefault(i => i.x == target.x && i.y == target.y) != null)
                    break;

                List<Location> AdjacentSquares = GetMovableAdjacentSpots(current.x, current.y, map);
                spot++;

                foreach (Location adjacentSquare in AdjacentSquares)
                {
                    if (closedList.FirstOrDefault(i => i.x == adjacentSquare.x && i.y == adjacentSquare.y) != null)
                        continue;
                    
                    if (closedList.FirstOrDefault(i => i.x == adjacentSquare.x && i.y == adjacentSquare.y) == null)
                    {
                        adjacentSquare.score2 = spot;
                        adjacentSquare.score3 = ComputeSpotHeuristic(adjacentSquare.x, adjacentSquare.y, target.x, target.y);
                        adjacentSquare.score1 = adjacentSquare.score2 + adjacentSquare.score3;
                        adjacentSquare.parent = current;
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        if(spot + adjacentSquare.score3 < adjacentSquare.score1)
                        {
                            adjacentSquare.score2 = spot;
                            adjacentSquare.score1 = adjacentSquare.score2 + adjacentSquare.score3;
                            adjacentSquare.parent = current;
                        }
                    }
                }
            }

            while(current != null)
            {
                Console.SetCursorPosition(current.x, current.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine('o');
                Console.SetCursorPosition(current.x, current.y);
                current = current.parent;

                System.Threading.Thread.Sleep(200);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();

        }

        private List<Location> GetMovableAdjacentSpots(int x, int y, string[] map)
        {
            List<Location> proposedLocations = new List<Location>()
            {
                new Location { x = x, y = y - 1 },
                new Location { x = x, y = y + 1 },
                new Location { x = x - 1 , y = y },
                new Location { x = x + 1, y = y },
            };

            return proposedLocations.Where(i => map[i.y][i.x] == ' ' || map[i.y][i.x] == 'B').ToList();
        }

        private int ComputeSpotHeuristic(int x, int y, int targetX, int targetY) => Math.Abs(targetX - x) + Math.Abs(targetY - y);
    }
}
