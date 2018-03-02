using System;

namespace MarsRoverChamus
{
    class Rover
    {
        private string Heading { get; set; }
        private int degree;
        private Coordinate Coordinate;

        //[Constructor]
        public Rover(Coordinate coordinate, string heading)
        {
            degree = HeadingToDegree(heading);
            Coordinate = coordinate;
        }

        //[Step 2: Creates Rover Object]
        public static Rover DeployRover(Coordinate plateauCoord)
        {
            //[Creating a new Coordinate Object and heading string for the Rover Object]
            View.ConsoleDeployInstructions();
            string[] input = Console.ReadLine().Split(' ');
            bool xBool = int.TryParse(input[0].ToString(), out int x);
            bool yBool = int.TryParse(input[1].ToString(), out int y);
            if (xBool == false || yBool == false)
            {
                throw new RoverFellOffThePlateauException();
            }
            Coordinate coordinate = new Coordinate(x, y);
            string heading = input[2].ToString().ToUpper();

            //[Testing for valid start Coordinate]
            if (coordinate.x > plateauCoord.x || coordinate.y > plateauCoord.y || coordinate.x < 0 || coordinate.y < 0)
            {
                throw new RoverFellOffThePlateauException();
            }
            else
            {
                //[New Rover]
                Rover rob = new Rover(coordinate, heading);
                return rob;
            }
        }

        //[Step 3: Moves Rover across Plateau based on input]
        public static void MoveRover(Rover rob, Coordinate plateauCoord)
        {

            View.ConsoleMoveInstructions();
            string input = Console.ReadLine().ToUpper();
            char[] nasaCommand = input.ToCharArray();
            for (int i = 0; i < nasaCommand.Length; i++)
            {
                if (nasaCommand[i] == 'L')
                {//[Turn Left]
                    rob.degree = rob.degree - 90;
                }
                else if (nasaCommand[i] == 'R')
                {//[Turn Right]
                    rob.degree = rob.degree + 90;
                }
                else if (nasaCommand[i] == 'M')
                {//[Move 1 in the Direction rover is facing]
                    switch (rob.degree)
                    {
                        case 0:
                            rob.Coordinate.y = rob.Coordinate.y + 1;
                            break;
                        case 360:
                            rob.Coordinate.y = rob.Coordinate.y + 1;
                            break;
                        case 90:
                            rob.Coordinate.x = rob.Coordinate.x + 1;
                            break;
                        case 180:
                            rob.Coordinate.y = rob.Coordinate.y - 1;
                            break;
                        case 270:
                            rob.Coordinate.x = rob.Coordinate.x - 1;
                            break;
                        default:
                            Console.WriteLine("Invalid Command #" + i + 1 + " - " + nasaCommand[i]);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Command #" + i + 1 + " -" + nasaCommand[i]);
                }
            }
            //[Overwrite original heading]
            rob.Heading = rob.DegreeToHeading(rob);
            //[Test for valid Coordinate]
            if (rob.Coordinate.x > plateauCoord.x || rob.Coordinate.y > plateauCoord.y || rob.Coordinate.x < 0 || rob.Coordinate.y < 0)
            {
                //[This throw will terminate the mission]
                throw new RoverFellOffThePlateauException();
            }
            else
            {
                Console.WriteLine(rob.Coordinate.x + "," + rob.Coordinate.y + " " + rob.Heading);
            }
        }

        //[Method to translate N,S,E,W value to a degree value out of 360]
        private static int HeadingToDegree(string heading)
        {
            int degree;
            switch (heading)
            {
                case "N":
                    degree = 0;
                    break;
                case "E":
                    degree = 90;
                    break;
                case "S":
                    degree = 180;
                    break;
                case "W":
                    degree = 270;
                    break;
                default:
                    degree = 0;
                    Console.WriteLine("Invalid Command, NASA has directed the Rover North");
                    break;

            }
            return degree;
        }

        //[Method to translate the degree value to a N,S,E,W value]
        private string DegreeToHeading(Rover rob)
        {
            if (rob.degree > 360)
            {
                rob.degree -= 360;
                return DegreeToHeading(rob);
            }
            else if (rob.degree < 0)
            {
                rob.degree += 360;
                return DegreeToHeading(rob);
            }
            else
            {
                switch (rob.degree)
                {
                    case 0:
                        return "N";
                    case 360:
                        return "N";
                    case 90:
                        return "E";
                    case 180:
                        return "S";
                    case 270:
                        return "W";
                    default:
                        degree = 0;
                        Console.WriteLine("Invalid Command, NASA has directed the Rover North");
                        return "N";
                }
            }
        }


    }
}
