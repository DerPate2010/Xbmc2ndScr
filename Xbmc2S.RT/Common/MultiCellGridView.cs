using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Xbmc2S.Model;

namespace Xbmc2S.RT
{
    public class MultiCellGridView : GridView
    {
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var multiCellItem= item as IMultiCellItem;
            if (multiCellItem != null)
            {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, multiCellItem.ColSpan);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, multiCellItem.RowSpan);
            }
            else
            {
                element.SetValue(VariableSizedWrapGrid.ColumnSpanProperty, 1);
                element.SetValue(VariableSizedWrapGrid.RowSpanProperty, 1);
            }
            base.PrepareContainerForItemOverride(element, item);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var sv = this.GetTemplateChild("ScrollViewer") as UIElement;
            if (sv != null)
                sv.AddHandler(UIElement.PointerWheelChangedEvent, new PointerEventHandler(OnPointerWheelChanged), true);
        }

        private void OnPointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = false;
        }

    }

}
