using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xbmc2S.Model
{
    public class GroupBase:BindableBase
    {
        private ObservableCollection<object> _items;
        public string Title { get; set; }
        public ObservableCollection<object> Items
        {
            get { return _items; }
            private set { _items = value; OnPropertyChanged();}
        }

        protected void RefreshTops(IEnumerable<object> allotems)
        {
            Items.Clear();
            foreach (var allotem in allotems)
            {
                Items.Add(allotem);
            }
        }

        public GroupBase()
        {
            Items= new ObservableCollection<object>();
        }
    }
}