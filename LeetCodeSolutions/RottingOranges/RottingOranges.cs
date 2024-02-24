namespace LeetCodeSolutions;
public class RottingOrangesSolution
{

    private class OrangeGrove
    {
        private class Coordinates(int x, int y)
        {
            public int X = x;
            public int Y = y;
        }
        private int[][] grid;
        public bool FreshOrangesFound;
        public bool RottenOrangesFound;
        Stack<Coordinates> rotPoints;

        public int Width => grid.Length;
        public int Height => grid[0].Length;

        public OrangeGrove(int[][] grid)
        {
            this.grid = grid;
            FreshOrangesFound = true;
            RottenOrangesFound = false;
            rotPoints = new();
        }

        private void MarkRotten(Coordinates rotPoint)
        {
            grid[rotPoint.X][rotPoint.Y] = 2;
        }

        public int Orange(int x, int y)
        {
            return grid[x][y];
        }


        private bool OutsideBounds(Coordinates coords)
        {
            return coords.X < 0 || coords.Y < 0 || coords.X >= Width || coords.Y >= Height;
        }


        private bool IsNullOrEmpty(Coordinates coords)
        {
            if (OutsideBounds(coords))
            {
                return true;
            }

            return grid[coords.X][coords.Y] == 0;

        }
        public bool InBoundsAndFresh(int x, int y)
        {
            if (OutsideBounds(new(x, y)))
            {
                return false;
            }

            return Orange(x, y) == 1;
        }

        public bool Isolated(int x, int y)
        {
            FreshOrangesFound = true;
            Coordinates left = new(x - 1, y);
            Coordinates right = new(x + 1, y);
            Coordinates top = new(x, y - 1);
            Coordinates bottom = new(x, y + 1);
            return IsNullOrEmpty(left) && IsNullOrEmpty(right) && IsNullOrEmpty(top) && IsNullOrEmpty(bottom);
        }

        public void SpoilAdjacentOranges()
        {
            FreshOrangesFound = false;
            while (rotPoints.Count > 0)
            {
                MarkRotten(rotPoints.Pop());
            }
        }

        public void MarkAdjacentFresh(int i, int j)
        {
            RottenOrangesFound = true;
            Coordinates left = new(i - 1, j);
            if (InBoundsAndFresh(i - 1, j))
            {
                rotPoints.Push(left);
            }
            Coordinates right = new(i + 1, j);
            if (InBoundsAndFresh(i + 1, j))
            {
                rotPoints.Push(right);
            }

            Coordinates top = new(i, j - 1);
            if (InBoundsAndFresh(i, j - 1))
            {
                rotPoints.Push(top);
            }
            Coordinates bottom = new(i, j + 1);
            if (InBoundsAndFresh(i, j + 1))
            {
                rotPoints.Push(bottom);
            }
        }
    }
    public int OrangesRotting(int[][] grid)
    {
        int minutes = 0;
        OrangeGrove orangeGrove = new(grid);

        while (true)
        {
            orangeGrove.SpoilAdjacentOranges();

            for (int i = 0; i < orangeGrove.Width; i++)
            {
                for (int j = 0; j < orangeGrove.Height; j++)
                {
                    switch (orangeGrove.Orange(i, j))
                    {
                        case 1:
                            if (orangeGrove.Isolated(i, j))
                            {
                                return -1;
                            }
                            break;
                        case 2:
                            orangeGrove.MarkAdjacentFresh(i, j);
                            break;
                    }
                }
            }

            if (orangeGrove.FreshOrangesFound)
            {
                if (!orangeGrove.RottenOrangesFound)
                {
                    return -1;
                }
                minutes++;
                continue;
            }

            return minutes;
        }
    }
}

