using System.Windows;

namespace imPhotoshop.Application.Common.Interfaces.Drawing;

public interface ILayer
{ 
    string Name { get; set; }
    void AddElement(UIElement element);
    void RemoveElement(UIElement element);
}
