using MarsRover.Services;
using MarsRover.Services.ServiceCommand;
using MarsRover.Services.ServicePlateau;
using MarsRover.Services.ServicePosition;
using MarsRover.Services.ServiceRover;
using Xunit;

namespace MarsRover.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var _appServices = ApplicationServices.ConfigureServices();

            var plateauService = (IPlateauService)_appServices.GetService(typeof(IPlateauService));
            plateauService.CreatePlateu("5 5");

            var positionService = (IPositionService)_appServices.GetService(typeof(IPositionService));
            positionService.SetPositionServiceFromInput("1 2 N");

            var commandService = (ICommandService)_appServices.GetService(typeof(ICommandService));
            commandService.CommandsParse("LMLMLMLMM");

            var roverService = (IRoverService)_appServices.GetService(typeof(IRoverService));
            roverService.RoverPlateau = plateauService;
            roverService.RoverPosition = positionService;
            roverService.RoverCommands = commandService;

            plateauService.AddRover(roverService);

            var actualOutput = roverService.Process(roverService);

            var expextedOutput = "1 3 N";

            Assert.Equal(expextedOutput, actualOutput);
        }
    }
}
