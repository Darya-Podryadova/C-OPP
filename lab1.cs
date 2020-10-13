using System;
using System.Collections.Generic;
using System.Collections;

namespace labyrinth
{

    class MazeSolver
    {
        private int[,] Maze;
        private List<int[]> coordStack;
        int xStart;
        int yStart;
        bool solved = false;

        public MazeSolver()
        { }

        public (int[,], List<int[]>) SolveMaze(int[,] maze, int xStart, int yStart)
        {

            this.Maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            this.coordStack = new List<int[]>();

            solved = false;

            obhod(yStart, xStart);

            return (Maze, coordStack);
        }

        private void obhod(int xcoord, int ycoord)
        {
            try
            {
                int up = xcoord - 1;
                int down = xcoord + 1;
                int left = ycoord - 1;
                int right = ycoord + 1;

                Maze[xcoord, ycoord] = 7;
                //Console.Write($"({xcoord}, {ycoord}) --> ");
                coordStack.Add(new int[] { xcoord, ycoord });

                if (Maze[down, ycoord] == 0 && !solved)
                {
                    obhod(down, ycoord);
                    if (!solved)
                    {
                        Maze[down, ycoord] = 3;
                    }
                }

                if (Maze[xcoord, left] == 0 && !solved)
                {
                    obhod(xcoord, left);
                    if (!solved)
                    {
                        Maze[xcoord, left] = 3;
                    }
                }

                if (Maze[up, ycoord] == 0 && !solved)
                {
                    obhod(up, ycoord);
                    if (!solved)
                    {
                        Maze[up, ycoord] = 3;
                    }
                }

                if (Maze[xcoord, right] == 0 && !solved)
                {
                    obhod(xcoord, right);
                    if (!solved)
                    {
                        Maze[xcoord, right] = 3;
                    }
                }
            }

            catch (IndexOutOfRangeException)
            {
                solved = true;
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {


            Console.Write("xstart = ");
            int X_START = Convert.ToInt32(Console.ReadLine());
            Console.Write("ystart = ");
            int Y_START = Convert.ToInt32(Console.ReadLine());

            int[,] maze1 = {{1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1},
                           {1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1},
                           {1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1},
                           {1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1},
                           {1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1},
                           {1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                           {1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1},
                           {1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1},
                           {1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1},
                           {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                           {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            };

            showMaze(maze1);

            MazeSolver mazeSolver = new MazeSolver();

            var name = mazeSolver.SolveMaze(maze1, X_START, Y_START);

            int[,] maze1solved = name.Item1;
            showMaze(maze1solved);

            List<int[]> Coordddinatttes = name.Item2;

            Coordinates(Coordddinatttes);



        }

        static int[,] inputMaze()
        {
            Console.Write("n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("m = ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Enter {n}x{m} matrix:");
            int[,] maze = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    maze[i, j] = Convert.ToInt32(Console.Read());
                }

            }

            return maze;
        }

        static void showMaze(int[,] mazeToShow)
        {
            for (int y = 0; y < mazeToShow.GetLength(0); y++)
            {
                for (int x = 0; x < mazeToShow.GetLength(1); x++)
                {
                    Console.Write($"{mazeToShow[y, x]} ");

                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Coordinates(List<int[]> coords)
        {
            foreach (int[] pair in coords)
            {
                Console.Write($"({pair[0]}, {pair[1]}), ");
            }

           
        }

    }
}
