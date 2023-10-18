
using System;
using System.Windows;
using Caliburn.Micro;
using System.Windows.Input;
using System.Collections.Generic;
using imPhotoshop.Infrastructure;
using Microsoft.Xaml.Behaviors.Input;
using imPhotoshop.Infrastructure.Drawing;
using imPhotoshop.Application.Common.Interfaces.Shell;
using imPhotoshop.Application.Common.Interfaces.Drawing;

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
        _container.Instance(_container)
                  .AddInfrastructureServices()
                  .AddWPFServices();

        ConfigureHotkeyBindings();
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

    private void ConfigureHotkeyBindings()
    {
        var defaultCreateTrigger = Parser.CreateTrigger;

        Parser.CreateTrigger = (target, triggerText) =>
        {
            if (triggerText == null)
            {
                return defaultCreateTrigger(target, null);
            }

            var triggerDetail = triggerText
                .Replace("[", string.Empty)
                .Replace("]", string.Empty);

            var splits = triggerDetail.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

            switch (splits[0])
            {
                case "Key":
                    var key = (Key)Enum.Parse(typeof(Key), splits[1], true);
                    return new KeyTrigger { Key = key };

                case "Gesture":
                    var mkg = (KeyGesture)(new KeyGestureConverter()).ConvertFrom(splits[1]);
                    return new KeyTrigger { Modifiers = mkg.Modifiers, Key = mkg.Key };
            }

            return defaultCreateTrigger(target, triggerText);
        };
    }
}
