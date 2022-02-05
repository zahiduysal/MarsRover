using MarsRover.Common.Logger;
using MarsRover.Services.ServicePlateau;

namespace MarsRover.App.Operations
{
    interface IMoveOperations
    {
        void Run(ILogger _logger, IPlateauService _plateauService);
    }
}
