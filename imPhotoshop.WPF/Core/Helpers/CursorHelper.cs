
using System.Windows;
using System.Windows.Input;

namespace imPhotoshop.WPF.Core.Helpers;

public static class CursorHelper
{
    public static Point GetRelativePosition(object sender, MouseEventArgs e)
    {
        return e.GetPosition(sender as IInputElement);
    }
}
