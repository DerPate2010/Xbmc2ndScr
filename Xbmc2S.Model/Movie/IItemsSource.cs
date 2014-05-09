using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Xbmc2S.Model
{
    public interface IItemsSource
    {
        string Caption { get; }
        object Selected { get; set; }
        IList Items { get; }
        INotifyCollectionChanged ChangeNotification { get; }
        ItemsSourceReference GetStateRepresentation();

        //void Goto(object clickedItem);
        void RestoreSelection(int index);
        Task WaitForSelection();
    }

    public interface IGroupedItemsSource : IItemsSource
    {
        Task<List<string>> FetchAllLabelsAsync();
    }
}