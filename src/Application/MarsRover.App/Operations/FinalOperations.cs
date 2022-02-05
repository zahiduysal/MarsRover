using MarsRover.Common.Input;
using MarsRover.Common.Logger;
using MarsRover.Services.ServicePlateau;
using System;

namespace MarsRover.App.Operations
{
    class FinalOperations : IFinalOperations
    {
        public int Run(ILogger _logger, IPlateauService _plateauService)
        {
            _logger.writeSeperator();
            _logger.writeLog("");
            _logger.writeLog("Aşağıdaki adımlar ile devam edebilirsiniz.");
            _logger.writeLog("1-Aynı plato ile tekrar gezici tanımlamak");
            _logger.writeLog("2-Farklı plato ile tekrar gezici tanımlamak");
            _logger.writeLog("0-Çıkış");

            try
            {
                int finalChoose = Convert.ToInt32(Input.getInputFromUser("Seçiminiz"));

                return finalChoose;
            }
            catch
            {
                return 0;
            }
        }
    }
}
