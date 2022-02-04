using MarsRover.Domain.Enumarations;

namespace MarsRover.Services.ServicePosition
{
    public interface IPositionService
    {
        #region properties
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
        #endregion

        #region functions
        public bool SetPositionServiceFromInput(string inputXYDirection);
        #endregion
    }
}
