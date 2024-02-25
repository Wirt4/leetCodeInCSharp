
using System.Security.Cryptography;

namespace LeetCodeSolutions;
public class RottingOrangesSolution
{
    private class Coordinates
    {
        private readonly int _x;
        private readonly int _y;
        public int X => _x;
        public int Y => _y;
        public Coordinates(int[] arr)
        {
            _x = arr[0];
            _y = arr[0];
        }

        public Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }

        private bool IsValid(int[][] grid)
        {
            return _x >= 0 && _y >= 0 && _x < grid.Length && _y < grid[0].Length;
        }

        public bool IsFresh(int[][] grid)
        {
            return IsValid(grid) && grid[_x][_y] == 1;
        }

        public bool IsRotten(int[][] grid)
        {
            return IsValid(grid) && grid[_x][_y] == 2;
        }
        private static string Encode(int num)
        {
            return num.ToString("000000");
        }
        public string ToString()
        {
            return Encode(_x) + Encode(_y);
        }
    }


    public int OrangesRotting(int[][] grid)
    {
        HashSet<string> allFresh = new();
        Queue<Coordinates> rottingNeighbors = new();
        int width = grid.Length;
        int height = grid[0].Length;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Coordinates current = new(i, j);
                if (current.IsFresh(grid))
                {
                    allFresh.Add(current.ToString());
                }
                if (current.IsRotten(grid))
                {
                    Coordinates left = new(current.X - 1, current.Y);
                    if (left.IsFresh(grid))
                    {
                        rottingNeighbors.Enqueue(left);
                    }

                    Coordinates right = new(current.X + 1, current.Y);

                    if (right.IsFresh(grid))
                    {
                        rottingNeighbors.Enqueue(right);
                    }

                    Coordinates top = new(current.X, current.Y - 1);
                    if (top.IsFresh(grid))
                    {
                        rottingNeighbors.Enqueue(top);
                    }

                    Coordinates bottom = new(current.X, current.Y + 1);
                    if (bottom.IsFresh(grid))
                    {
                        rottingNeighbors.Enqueue(bottom);
                    }
                }
            }
        }

        int minutes = 0;

        while (rottingNeighbors.Count > 0)
        {

            foreach (Coordinates neighbor in rottingNeighbors)
            {
                allFresh.Remove(neighbor.ToString());
            }

            int neighborCount = rottingNeighbors.Count;
            for (int i = 0; i < neighborCount; i++)
            {
                Coordinates current = rottingNeighbors.Dequeue();

                Coordinates left = new(current.X - 1, current.Y);
                if (allFresh.Contains(left.ToString()))
                {
                    rottingNeighbors.Enqueue(left);
                }
                Coordinates right = new(current.X + 1, current.Y);
                if (allFresh.Contains(right.ToString()))
                {
                    rottingNeighbors.Enqueue(right);
                }

                Coordinates top = new(current.X, current.Y - 1);
                if (allFresh.Contains(top.ToString()))
                {
                    rottingNeighbors.Enqueue(top);
                }
                Coordinates bottom = new(current.X, current.Y + 1);
                if (allFresh.Contains(bottom.ToString()))
                {
                    rottingNeighbors.Enqueue(bottom);
                }
            }
            minutes++;
        }


        return allFresh.Count == 0 ? minutes : -1;
    }

}