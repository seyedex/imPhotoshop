using imPhotoshop.Application.Common.Interfaces.Navigation;

namespace imPhotoshop.WPF.ViewModels;

public class RegistrationViewModel
{
    #region Variables

    private readonly INavigator _navigator;

    #endregion // Variables


    #region Properties
    #endregion // Properties


    #region Constructor

    public RegistrationViewModel(INavigator navigator)
    {
        _navigator = navigator;
    }

    #endregion // Constructor


    #region Methods

    public void Register()
    {
        _navigator.To<MainViewModel>().Go();
    }

    public void Login()
    {
        _navigator.To<LoginViewModel>().Go();
    }

    #endregion // Methods
}
