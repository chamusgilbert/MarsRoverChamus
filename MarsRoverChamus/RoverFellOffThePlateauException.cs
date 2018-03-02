using System;

namespace MarsRoverChamus
{
    class RoverFellOffThePlateauException : Exception
    {
        //[Exception for when the Rover's Coordinates are less than 0 or greater than the PlateauSize]
        public RoverFellOffThePlateauException()
        {
            Console.WriteLine("Your Rover fell over the edge of the plateau");
            return;
        }
    }
}
