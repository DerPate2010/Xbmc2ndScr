using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xbmc2S.Model;

namespace Xbmc2S.RT
{

    
    public class FileTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var fileInfo = item as FileInfo;
            if (fileInfo != null)
                return FileTemplate;

            return DirectoryTemplate;
        }

        public DataTemplate FileTemplate { get; set; }
        public DataTemplate DirectoryTemplate { get; set; }
    }
}
