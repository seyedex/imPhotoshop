
using System.Windows;

namespace imPhotoshop.WPF.Views;

public partial class MainWindow : Window
{
    public MainWindow(object dataContext)
    {
        InitializeComponent();

        this.DataContext = dataContext;
    }
}
