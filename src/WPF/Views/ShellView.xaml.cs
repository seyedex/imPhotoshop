
using System.Windows;
using System.Windows.Input;

namespace imPhotoshop.WPF.Views;

public partial class ShellView : Window
{
    public ShellView()
    {
        InitializeComponent();
    }

    private void topPanelBorder_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            this.DragMove();
    }

    private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void MaximizeWindowButton_Click(object sender, RoutedEventArgs e)
    {
        if (System.Windows.Application.Current.MainWindow.WindowState != WindowState.Maximized)
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Maximized;
        else
            System.Windows.Application.Current.MainWindow.WindowState = WindowState.Normal;
    }

    private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
    {
        System.Windows.Application.Current.Shutdown();
    }
}
