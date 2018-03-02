using System;

namespace MarsRoverChamus
{
    class Program
    {
        static void Main()
        {
            char delimiter = ',';
            bool mission = true;
            string plate = PlateauSize();
            string[] plateau = plate.Split(delimiter);
            bool xTrue = int.TryParse(plateau[0], out int x);
            bool yTrue = int.TryParse(plateau[1], out int y);
            if (xTrue == true && yTrue == true)
            {
                Console.WriteLine(x + ", " + y);
            }
            else
            {
                Console.WriteLine("Try Again");
                Main();
            }
            while (mission == true)
            {
                try
                {
                    Rover rob = Rover.DeployRover(x, y);
                    Rover.MoveRover(rob, x, y);
                }
                catch (RoverFellOffThePlateauException)
                {

                }

                Console.WriteLine("Would you like to deploy another Rover?");
                string reply = Console.ReadLine().ToLower();
                if (reply == "y" || reply == "yes")
                {
                    mission = true;
                }
                else if (reply == "n" || reply == "no")
                {
                    Console.WriteLine("Mission Aborted");
                    mission = false;
                }
                else
                {
                    Console.WriteLine("Mission Aborted: Did not compute");
                    mission = false;
                }
            }
        }
        public static string PlateauSize()
        {
            Console.WriteLine("Give the dimensions of the plateau");
            Console.WriteLine("Use the following format: x,y");
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
