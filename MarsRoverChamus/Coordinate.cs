using System;

namespace MarsRoverChamus
{
    class Coordinate
    {
        public int x;
        public int y;

        //[Constructor]
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //[Method used for Step 1 to set the dimensions for the plateau]
        public static Coordinate CalculatePlateau()
        {
            string plate = PlateauSize();
            string[] plateau = plate.Split(' ');
            bool xTrue = int.TryParse(plateau[0], out int x);
            bool yTrue = int.TryParse(plateau[1], out int y);
            if (xTrue == true && yTrue == true)
            {
                Coordinate plateauCoord = new Coordinate(x, y);
                return plateauCoord;
            }
            else
            {
                return CalculatePlateau();
            }
        }

        //[Gives instructions for setting PlateauSize]
        public static string PlateauSize()
        {
            Console.WriteLine("Give the dimensions of the plateau");
            Console.WriteLine("Lower-left corner will be 0, 0");
            Console.WriteLine("Use the following format: x y");
            string dimensions = Console.ReadLine();
            if (dimensions.Length != 3)
            {
                return PlateauSize();
            }
            else
            {
                return dimensions;
            }
        }

    }
}
