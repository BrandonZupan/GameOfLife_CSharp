using System;

namespace GameOfLife
{
    class Life
    {
        string file_name = "../../../worlds/example.txt";
        const int num_generations = 2;

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

            life.show_world();

            //for (int iteration = 0; iteration < num_generations; iteration++)
            //{
            //    // clear screen

            //    life.iterate_generation();

            //    life.show_world();
            //}


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
        }

        void show_world()
        {
            for (int i = 0; i < num_rows; i++)
            {
                Console.WriteLine(world[i]);
            }
        }

        void iterate_generation()
        {

        }

    }
}
