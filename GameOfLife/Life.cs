using System;

namespace GameOfLife
{
    class Life
    {
        string file_name = @"C:\Users\Brandon\source\repos\GameOfLife\GameOfLife\worlds\pentadecathlon.txt";
        const int num_generations = 10;

        const int MAX_ROWS = 80;

        // array of strings that will hold the grid
        string[] world;
        int num_rows;
        int num_cols;

        static void Main(string[] args)
        {
            Life life = new Life();
            life.world = new string[MAX_ROWS];

            life.populate_world();

            // life.show_world();

            for (int iteration = 0; iteration < num_generations; iteration++)
            {
                // clear screen

                life.iterate_generation();

                life.show_world();
            }


        }

        // Read world file and fill into life.world
        void populate_world()
        {
            string[] lines = System.IO.File.ReadAllLines(file_name);
            if (lines.Length > MAX_ROWS)
            {
                Console.WriteLine("Error: Line too big");
                Environment.Exit(1);
            }

            int i;
            for (i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                foreach (char cell in line)
                {
                    if (cell == '0')
                    {
                        world[i] += '.';
                    }
                    else if (cell == '1')
                    {
                        world[i] += '*';
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid character %s", cell);
                    }
                }
            }
            num_rows = i;
            num_cols = world[0].Length;
        }

        void show_world()
        {
            for (int i = 0; i < num_rows; i++)
            {
                Console.WriteLine(world[i]);
            }
            Console.WriteLine();
        }

        void iterate_generation()
        {
            // Any live cell with 2 or 3 live neighbors survives
            // Any dead cell with three live neighbors becomes a live cell
            // All other live cells die in the next generation. All other dead cells stay dead

            string[] new_world = new string[MAX_ROWS];

            for (int row = 0; row < num_rows; row++)
            {
                for (int col = 0; col < num_cols; col++)
                {
                    int num_neighbors = count_neighbors(row, col);

                    if (world[row][col] == '*' && (num_neighbors == 2 || num_neighbors == 3))
                    {
                        new_world[row] += '*';
                    }
                    else if (world[row][col] == '.' && num_neighbors == 3)
                    {
                        new_world[row] += '*';
                    }
                    else
                    {
                        new_world[row] += '.';
                    }
                }
            }

            world = new_world;


        }

        int count_neighbors(int row, int col)
        {
            int neighbors = 0;
            for (int col_index = -1; col_index < 2; col_index++)
            {
                for (int row_index = -1; row_index < 2; row_index++)
                {
                    if (row_index != 0 && col_index != 0)
                    {
                        int line_num = row + row_index;
                        if (line_num >= 0 && line_num < num_rows)
                        {
                            int col_num = col + col_index;
                            if (col_num >= 0 && col_num < num_cols)
                            {
                                if (world[line_num][col_num] == '*')
                                {
                                    neighbors++;
                                }
                            }
                        }
                    }
                }
            }
            return neighbors;
        }

    }
}
