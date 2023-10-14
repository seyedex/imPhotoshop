
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace imPhotoshop.WPF.Core.Helpers;

public static class ImageHelper
{
    public static Image GetImage(string uri)
    {
        var filePath = new System.Uri(uri);
        var imageSource = new BitmapImage(filePath);
        return new Image { Source = imageSource };
    }
}
