
using System.Windows;
using System.Windows.Input;

namespace imPhotoshop.WPF.Views;

public partial class MainWindow : Window
{
    public MainWindow(object dataContext)
    {
        InitializeComponent();

        this.DataContext = dataContext;
    }

    private void topPanelBorder_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            this.DragMove();
    }

    private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow.WindowState = WindowState.Minimized;
    }

    private void MaximizeWindowButton_Click(object sender, RoutedEventArgs e)
    {
        if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        else 
            Application.Current.MainWindow.WindowState = WindowState.Normal;
    }

    private void CloseWindowButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}
