using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Xbmc2S.Model
{
    public class WatchList:BindableBase
    {
        private readonly IAppContext _appContext;
        private ObservableCollection<WatchListItem> _items;
        private Task _loadTask;
        private const string SettingsKey = "WatchList";

        public WatchList(IAppContext appContext)
        {
            _appContext = appContext;
        }

        public ObservableCollection<WatchListItem> Items
        {
            get
            {
                if (_items == null && _loadTask==null)
                {
                    _loadTask = LoadData();
                }
                return _items;
            }
            private set { SetProperty(ref _items, value); }
        }
        private async Task LoadData()
        {
            Items = await _appContext.PlatformServices.SettingsManager.LoadData(SettingsKey, () => new ObservableCollection<WatchListItem>(),true);
        }

        public async Task AddItem(PlayableItemVm item)
        {
            await AssureInit();
            if (Items.Any(i => i.Id == item.Id)) return;
            var newItem = new WatchListItem(item);

            Items.Add(newItem);
            await Persist();
        }

        private async Task AssureInit()
        {
            if (Items == null)
            {
                await _loadTask;
            }
        }

        public async Task RemoveItem(WatchListItem item)
        {
            await AssureInit();

            Items.Remove(item);
            await Persist();
        }

        private async Task Persist()
        {
            await _appContext.PlatformServices.SettingsManager.SaveData(SettingsKey, Items, true);
        }
    }
}