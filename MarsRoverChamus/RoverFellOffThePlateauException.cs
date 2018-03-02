using System;

namespace MarsRoverChamus
{
    class RoverFellOffThePlateauException : Exception
    {
        public RoverFellOffThePlateauException()
        {
            Console.WriteLine("Your Rover fell over the edge of the plateau");
            return;
        }
    }
}
