using MarsRover.Common.Input;
using MarsRover.Common.Logger;
using MarsRover.Services.ServicePlateau;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.App.Operations
{
    class PlateuOperations : IPlateuOperations
    {
        public void Run(ILogger _logger,ServiceProvider _appServices, IPlateauService _plateauService)
        {
            _logger.writeSeperator();
            bool plateauCheck = false;
            do
            {
                var plateauSize = Input.getInputFromUser("Plato Alanı Giriniz");
                plateauCheck = _plateauService.CreatePlateu(plateauSize);
                if (plateauCheck)
                    _logger.writeSuccessLog("Plato Alanı Başarıyla Oluşturuldu.");
                else
                    _logger.writeErrorLog("Plato Alanı Oluşturulamadı!(Örnek Plato Formatı-X Y)");

            } while (!plateauCheck);

            _logger.writeSeperator();
        }
    }
}
