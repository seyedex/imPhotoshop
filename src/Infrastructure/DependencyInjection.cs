using Caliburn.Micro;
using imPhotoshop.Infrastructure.Drawing;
using imPhotoshop.Infrastructure.Mediators;
using imPhotoshop.Infrastructure.Extensions;
using imPhotoshop.Infrastructure.Collections;
using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Mediators;
using imPhotoshop.Application.Common.Interfaces.Collections;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace imPhotoshop.Infrastructure;

public static class DependencyInjection
{
    public static SimpleContainer AddInfrastructureServices(this SimpleContainer container)
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

        return container.Instance<IConfiguration>(config)
                        .AddRepositories()
                        .AddDatabase()
                        .AddServices()
                        .PerRequest<ILayer, CanvasLayer>()
                        .Singleton<ILayerCollection, LayerCollection>()
                        .Singleton<IObservableLayerCollection, ObservableLayerCollection>()
                        .Singleton<ILayerMediator, LayerMediator>()
                        .Singleton<IToolMediator, ToolMediator>()
                        .Singleton<IDrawingOptions, DrawingOptions>();
    }
}
