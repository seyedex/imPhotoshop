
using System;
using System.Windows;
using Caliburn.Micro;
using System.Collections.Generic;
using imPhotoshop.WPF.ViewModels;

namespace imPhotoshop.WPF;

public class Bootstrapper : BootstrapperBase
{
    private readonly SimpleContainer _container = new SimpleContainer();

    public Bootstrapper()
    {
        Initialize();

        LogManager.GetLog = type => new DebugLog(type);
    }

    protected override async void OnStartup(object sender, StartupEventArgs e)
    {
        await DisplayRootViewForAsync<ShellViewModel>();
    }

    protected override void Configure()
    {
        _container.Instance(_container);

        _container.Singleton<IWindowManager, WindowManager>();

        _container.PerRequest<ShellViewModel>();
        _container.PerRequest<ToolPanelViewModel>();
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
