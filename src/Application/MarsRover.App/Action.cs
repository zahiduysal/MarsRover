using MarsRover.Common.Input;
using MarsRover.Common.Logger;
using MarsRover.Services;
using MarsRover.Services.ServiceCommand;
using MarsRover.Services.ServicePlateau;
using MarsRover.Services.ServicePosition;
using MarsRover.Services.ServiceRover;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRover.App
{
    class Action : IDisposable
    {
        readonly ServiceProvider _appServices;
        readonly ILogger _logger;
        public Action() 
        {
            this._appServices = ApplicationServices.ConfigureServices();
            this._logger = new Logger();
        }

        public void Run()
        {
            PlateuOperations();
        }

        private void PlateuOperations()
        {
            _logger.writeSeperator();
            bool plateauCheck = false;
            var plateauService = (IPlateauService)_appServices.GetService(typeof(IPlateauService));
            do
            {
                var plateauSize = Input.getInputFromUser("Plato Alanı Giriniz");
                plateauCheck = plateauService.CreatePlateu(plateauSize);
                if (plateauCheck)
                    _logger.writeSuccessLog("Plato Alanı Başarıyla Oluşturuldu.");
                else
                    _logger.writeErrorLog("Plato Alanı Oluşturulamadı!(Örnek Plato Formatı-X Y)");

            } while (!plateauCheck);

            _logger.writeSeperator();

            RoverOperations(plateauService);
        }

        private void RoverOperations(IPlateauService plateauService)
        {
            bool isAnotherRover = true;
            plateauService.Rovers.Clear();
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
                roverService.RoverPlateau = plateauService;
                roverService.RoverPosition = positionService;
                roverService.RoverCommands = commandService;

                plateauService.AddRover(roverService);

                _logger.writeSuccessLog("Gezici Başarıyla Tanımlandı.");
                _logger.writeSeperator();

                var continueRover = Input.getInputFromUser("Bir Adet Daha Gezici Tanımlamak İster misiniz?(Devam etmek için Y yazınız!)");
                if (continueRover.ToUpper() != "Y")
                    isAnotherRover = false;

            } while (isAnotherRover);

            MoveOperations(plateauService);
        }

        private void MoveOperations(IPlateauService plateauService)
        {
            _logger.writeLog("");
            _logger.writeLog("Expected Output: ");
            foreach (IRoverService rover in plateauService.Rovers)
                _logger.writeLog(rover.Process(rover));

            FinalOperations(plateauService);
        }

        private void FinalOperations(IPlateauService plateauService)
        {
            _logger.writeSeperator();
            _logger.writeLog("");
            _logger.writeLog("Aşağıdaki adımlar ile devam edebilirsiniz.");
            _logger.writeLog("1-Aynı plato ile tekrar gezici tanımlamak");
            _logger.writeLog("2-Farklı plato ile tekrar gezici tanımlamak");
            _logger.writeLog("3-Çıkış");

            try
            {
                int finalChoose = Convert.ToInt32(Input.getInputFromUser("Seçiminiz"));

                if (finalChoose == 2)
                    PlateuOperations();
                else if (finalChoose == 1)
                    RoverOperations(plateauService);
                else
                    Environment.Exit(0);
            }
            catch
            {
                Environment.Exit(0);
            }           
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
