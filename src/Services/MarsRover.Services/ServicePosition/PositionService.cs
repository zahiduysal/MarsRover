using MarsRover.Domain.Enumarations;
using System;

namespace MarsRover.Services.ServicePosition
{
    public class PositionService: IPositionService
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public PositionService()
        {
            this.X = 0;
            this.Y = 0;
            this.Direction = Directions.N;
        }

        public bool SetPositionServiceFromInput(string inputXYDirection)
        {
            try
            {
                this.X = Convert.ToInt32(inputXYDirection.Split(' ')[0].ToString());
                this.Y = Convert.ToInt32(inputXYDirection.Split(' ')[1].ToString());
                this.Direction = (Directions)Enum.Parse(typeof(Directions), inputXYDirection.Split(' ')[2].ToString().ToUpper(), true);  
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
