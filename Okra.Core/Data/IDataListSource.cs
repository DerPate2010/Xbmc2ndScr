using System;
using System.Threading.Tasks;

namespace Okra.Data
{
    public interface IDataListSource<T>
    {
        // *** Methods ***

        Task<int> GetCountAsync();
        Task<T> GetItemAsync(int index);
        int IndexOf(T item);

        IDisposable Subscribe(IUpdatableCollection collection);
    }
}
