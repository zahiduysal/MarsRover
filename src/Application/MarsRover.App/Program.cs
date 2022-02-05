using MarsRover.Domain.Constant;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action();
            action.Run(Constant.NewPlateuOperations);
        }
    }
}
