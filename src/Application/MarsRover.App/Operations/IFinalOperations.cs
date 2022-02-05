using MarsRover.Common.Logger;
using MarsRover.Services.ServicePlateau;

namespace MarsRover.App.Operations
{
    interface IFinalOperations
    {
        int Run(ILogger _logger, IPlateauService _plateauService);
    }
}
