
using System.Collections.Generic;
using System.Linq;

namespace imPhotoshop.WPF.Core.Builders;

public static class FileExtensionFilterBuilder
{
    public static FileExtensionFilter Confiure()
    {
        return new FileExtensionFilter();
    }

    public static string Build(this FileExtensionFilter filter)
    {
        return filter.BuildUp();
    }

    public class FileExtensionFilter
    {
        /*private List<FileExtensions> _extensions;

        public FileExtensionFilter AddExtension(FileExtensionsS extension)
        {
            _extensions.Add(extension);
            return this;
        }*/

        public string BuildUp()
        {
            return string.Empty;
        }
    }
}
