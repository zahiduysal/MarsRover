using MarsRover.Services.ServiceCommand;
using MarsRover.Services.ServicePlateau;
using MarsRover.Services.ServicePosition;
using MarsRover.Services.ServiceRover;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Services
{
    public class ApplicationServices
    {
        public static ServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.Add(new ServiceDescriptor(typeof(IPlateauService), typeof(PlateauService), ServiceLifetime.Transient));
            serviceCollection.Add(new ServiceDescriptor(typeof(IRoverService), typeof(RoverService), ServiceLifetime.Transient));
            serviceCollection.Add(new ServiceDescriptor(typeof(IPositionService), typeof(PositionService), ServiceLifetime.Transient));
            serviceCollection.Add(new ServiceDescriptor(typeof(ICommandService), typeof(CommandService), ServiceLifetime.Transient));
            return serviceCollection.BuildServiceProvider();
        }
    }
}
