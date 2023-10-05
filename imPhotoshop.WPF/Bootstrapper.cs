
using System;
using System.Windows;
using Caliburn.Micro;
using System.Collections.Generic;
using imPhotoshop.WPF.ViewModels;
using imPhotoshop.WPF.Models.Drawing;
using imPhotoshop.WPF.Core.Collections;
using imPhotoshop.WPF.Models.Mediators;
using imPhotoshop.WPF.Models.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Shell;
using imPhotoshop.WPF.Core.Interfaces.Drawing;
using imPhotoshop.WPF.Core.Interfaces.Mediators;
using imPhotoshop.WPF.Core.Interfaces.Navigation;
using imPhotoshop.WPF.Core.Interfaces.Collections;

namespace imPhotoshop.WPF;

public class Bootstrapper : BootstrapperBase
{
    private readonly SimpleContainer _container = new SimpleContainer();

    public Bootstrapper()
    {
        Initialize();

        LogManager.GetLog = (type) => new DebugLog(type);
    }

    protected override async void OnStartup(object sender, StartupEventArgs e)
    {
        await DisplayRootViewForAsync<IShell>();
    }

    protected override void Configure()
    {
        _container.Instance(_container);

        _container.Singleton<IWindowManager, WindowManager>();
        _container.Singleton<ICommandHistory, CommandHistory>();
        _container.Singleton<IToolMediator, ToolMediator>();
        _container.Singleton<ILayersMediator, LayersMediator>();
        _container.Singleton<ILayerCollection, LayerCollection>();
        _container.Instance<INavigator>(new Navigator(new Lazy<IShell>(() => _container.GetInstance<IShell>())));
        _container.PerRequest<ILayer, CanvasLayer>();

        _container.Singleton<CanvasViewModel>();
        _container.Singleton<ToolPanelViewModel>();
        _container.Singleton<LayersViewModel>();
        _container.Singleton<WorkspaceViewModel>();
        _container.Singleton<IShell, ShellViewModel>();
    }

    protected override object GetInstance(Type service, string key)
    {
        return _container.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return _container.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        _container.BuildUp(instance);
    }
}
