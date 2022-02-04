using MarsRover.Services.ServiceCommand;
using MarsRover.Services.ServicePlateau;
using MarsRover.Services.ServicePosition;

namespace MarsRover.Services.ServiceRover
{
    public interface IRoverService
    {
        #region properties
        IPositionService RoverPosition { get; set; }
        IPlateauService RoverPlateau { get; set; }
        ICommandService RoverCommands { get; set; }
        #endregion

        #region functions
        string Process(IRoverService rover);
        #endregion
    }
}
