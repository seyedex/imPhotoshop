using Caliburn.Micro;
using System.Windows;
using System.Security;
using System.Windows.Controls;
using imPhotoshop.Application.Common.Interfaces.Navigation;

namespace imPhotoshop.WPF.ViewModels;

public class LoginViewModel : Screen
{
    #region Variables

    private readonly INavigator _navigator;

    #endregion // Variables


    #region Properties

    public string? Username { get; set; }
    public SecureString? Password { get; set; }

    #endregion // Properties


    #region Constructor

    public LoginViewModel(INavigator navigator)
    {
        _navigator = navigator;
    }

    #endregion // Constructor


    #region Methods

    public void Login()
    {
        _navigator.To<MainViewModel>().Go();
    }

    public void CreateAccount()
    {
        // TODO
    }

    public void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        Password = ((PasswordBox)sender).SecurePassword;
    }

    #endregion // Methods
}
