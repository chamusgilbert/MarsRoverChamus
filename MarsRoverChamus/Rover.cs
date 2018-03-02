using System;

namespace MarsRoverChamus
{
    class Rover
    {
        private string heading;
        private int degree;
        private int x;
        private int y;

        public Rover(int x, int y, string heading)
        {
            this.heading = heading;
            degree = HeadingToDegree(heading);
            this.x = x;
            this.y = y;


        }
        public static Rover DeployRover(int xLimit, int yLimit)
        {
            char comma = ',';
            View.ConsoleDeployInstructions();
            string[] nasaSet = Console.ReadLine().Split(comma);
            int x = int.Parse(nasaSet[0]);
            int y = int.Parse(nasaSet[1]);
            string heading = nasaSet[2].ToUpper();
            if (x > xLimit || y > yLimit || x < 0 || y < 0)
            {
                throw new RoverFellOffThePlateauException();
            }
            else
            {
                Rover rob = new Rover(x, y, heading);
                return rob;
            }
        }
        public static void MoveRover(Rover rob, int xLimit, int yLimit)
        {
            rob.degree = HeadingToDegree(rob.heading);
            View.ConsoleMoveInstructions();
            string input = Console.ReadLine().ToUpper();
            char[] nasaCommand = input.ToCharArray();
            for (int i = 0; i < nasaCommand.Length; i++)
            {
                if (nasaCommand[i] == 'L')
                {
                    rob.degree = rob.degree - 90;
                }
                else if (nasaCommand[i] == 'R')
                {
                    rob.degree = rob.degree + 90;
                }
                else if (nasaCommand[i] == 'M')
                {
                    switch (rob.degree)
                    {
                        case 0:
                            rob.y = rob.y + 1;
                            break;
                        case 360:
                            rob.y = rob.y + 1;
                            break;
                        case 90:
                            rob.x = rob.x + 1;
                            break;
                        case 180:
                            rob.y = rob.y - 1;
                            break;
                        case 270:
                            rob.x = rob.x - 1;
                            break;
                        default:
                            Console.WriteLine("Invalid Command #" + i + " - " + nasaCommand[i]);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Command #" + i + " -" + nasaCommand[i]);
                }
            }
            rob.heading = rob.DegreeToHeading(rob);
            if (rob.x > xLimit || rob.y > yLimit || rob.x < 0 || rob.y < 0)
            {
                throw new RoverFellOffThePlateauException();
            }
            else
            {
                Console.WriteLine(rob.x + "," + rob.y + " " + rob.heading);
            }
        }
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
