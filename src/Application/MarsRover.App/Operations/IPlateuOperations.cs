using MarsRover.Common.Logger;
using MarsRover.Services.ServicePlateau;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.App.Operations
{
    interface IPlateuOperations
    {
        void Run(ILogger _logger, ServiceProvider _appServices, IPlateauService _plateauService);
    }
}
