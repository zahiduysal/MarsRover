using MarsRover.App.Operations;
using MarsRover.Common.Logger;
using MarsRover.Domain.Constant;
using MarsRover.Services;
using MarsRover.Services.ServicePlateau;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.App
{
    class Action : IDisposable
    {
        readonly ServiceProvider _appServices;
        readonly ILogger _logger;
        readonly IPlateauService _plateauService;
        readonly IPlateuOperations _plateuOperations;
        readonly IRoverOperations _roverOperations;
        readonly IMoveOperations _moveOperations;
        readonly IFinalOperations _finalOperations;

        public Action() 
        {
            this._appServices = ApplicationServices.ConfigureServices();
            this._logger = new Logger();
            this._plateauService = (IPlateauService)_appServices.GetService(typeof(IPlateauService));
            this._plateuOperations = new PlateuOperations();
            this._roverOperations = new RoverOperations();
            this._moveOperations = new MoveOperations();
            this._finalOperations = new FinalOperations();
        }

        public void Run(int runVal)
        {
            if(runVal == Constant.NewPlateuOperations)
            {
                _plateuOperations.Run(_logger, _appServices, _plateauService);
                _roverOperations.Run(_logger, _appServices, _plateauService);
                _moveOperations.Run(_logger, _plateauService);
            }
            else if(runVal == Constant.SamePlateuOperations)
            {
                _roverOperations.Run(_logger, _appServices, _plateauService);
                _moveOperations.Run(_logger, _plateauService);
            }
            else
                Environment.Exit(0);

            int finalChoose = _finalOperations.Run(_logger, _plateauService);
            Run(finalChoose);
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
