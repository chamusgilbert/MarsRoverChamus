using System;

namespace MarsRoverChamus
{
    class Program
    {
        static void Main()
        {
            bool mission = true;
            //[Step 1: Setting the Dimensions of the Plateau]
            Coordinate plateauCoord = Coordinate.CalculatePlateau();

            //[Loop] I placed this in a loop to give NASA the option to deploy as many Rovers as needed.
            while (mission == true)
            {
                //[Step 2: DeployRover Method will build a Rover Object]
                Rover rob = Rover.DeployRover(plateauCoord);

                //[Step 3: MoveRover Method takes input data, and changes the Rover's Direction/Heading and Coordinates on the Plateau]
                Rover.MoveRover(rob, plateauCoord);

                //[Continue the Loop or End the Loop]
                mission = Continue(mission);
            }
        }
        public static bool Continue(bool mission)
        {
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
            return mission;
        }
    }
}

