using MarsRover.Common.Input;
using MarsRover.Common.Logger;
using MarsRover.Services.ServiceCommand;
using MarsRover.Services.ServicePlateau;
using MarsRover.Services.ServicePosition;
using MarsRover.Services.ServiceRover;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.App.Operations
{
    class RoverOperations : IRoverOperations
    {
        public void Run(ILogger _logger, ServiceProvider _appServices, IPlateauService _plateauService)
        {
            bool isAnotherRover = true;
            _plateauService.Rovers.Clear();
            do
            {
                var positionService = (IPositionService)_appServices.GetService(typeof(IPositionService));
                var roverPosition = Input.getInputFromUser("Gezici Pozisyonu Giriniz");
                while (!positionService.SetPositionServiceFromInput(roverPosition))
                {
                    _logger.writeErrorLog("Gezici Pozisyonu Atanamadı!(Örnek Gezici Pozisyonu Formatı: X Y N)");
                    roverPosition = Input.getInputFromUser("Gezici Pozisyonu Giriniz");
                }

                var commandService = (ICommandService)_appServices.GetService(typeof(ICommandService));
                var roverCommand = Input.getInputFromUser("Gezici Komutu Giriniz");
                while (!commandService.CommandsParse(roverCommand))
                {
                    _logger.writeErrorLog("Gezici Komutu Atanamadı!");
                    roverCommand = Input.getInputFromUser("Gezici Komutu Giriniz");
                }

                var roverService = (IRoverService)_appServices.GetService(typeof(IRoverService));
                roverService.RoverPlateau = _plateauService;
                roverService.RoverPosition = positionService;
                roverService.RoverCommands = commandService;

                _plateauService.AddRover(roverService);

                _logger.writeSuccessLog("Gezici Başarıyla Tanımlandı.");
                _logger.writeSeperator();

                var continueRover = Input.getInputFromUser("Bir Adet Daha Gezici Tanımlamak İster misiniz?(Devam etmek için Y yazınız!)");
                if (continueRover.ToUpper() != "Y")
                    isAnotherRover = false;

            } while (isAnotherRover);
        }
    }
}
