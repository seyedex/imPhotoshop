using Caliburn.Micro;
using imPhotoshop.Infrastructure.Drawing;
using imPhotoshop.Infrastructure.Mediators;
using imPhotoshop.Infrastructure.Navigation;
using imPhotoshop.Infrastructure.Collections;
using imPhotoshop.Application.Common.Interfaces.Shell;
using imPhotoshop.Application.Common.Interfaces.Drawing;
using imPhotoshop.Application.Common.Interfaces.Mediators;
using imPhotoshop.Application.Common.Interfaces.Navigation;
using imPhotoshop.Application.Common.Interfaces.Collections;

namespace imPhotoshop.Infrastructure;

public static class DependencyInjection
{
    public static SimpleContainer AddInfrastructureServices(this SimpleContainer container)
    {
        container.PerRequest<ILayer, CanvasLayer>()
                  .Singleton<IWindowManager, WindowManager>()
                  .Singleton<ICommandHistory, CommandHistory>()
                  .Singleton<ILayerCollection, LayerCollection>()
                  .Singleton<IObservableLayerCollection, ObservableLayerCollection>()
                  .Singleton<ILayerMediator, LayerMediator>()
                  .Singleton<IToolMediator, ToolMediator>()
                  .Singleton<IDrawingOptions, DrawingOptions>();

        var lazyShellFactory = new Lazy<IShell>(() => container.GetInstance<IShell>());
        container.Instance<INavigator>(new Navigator(lazyShellFactory, container));

        return container;
    }
}
