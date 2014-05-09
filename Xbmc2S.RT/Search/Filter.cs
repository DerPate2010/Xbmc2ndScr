using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Okra.Data;
using Xbmc2S.Model;
using BindableBase = Xbmc2S.RT.Common.BindableBase;

namespace Xbmc2S.RT
{
    internal class Filter : BindableBase
    {
        private readonly IItemsSource _source;
        private String _name;
        private int _count;
        private bool _active;

        public Filter(String name, IItemsSource source=null, DataTemplate itemTemplate=null)
        {
            _source = source;
            this.Name = name;
            ItemTemplate = itemTemplate;
            if (_source != null)
            {
                GetResultCount();
            }
        }


        private async Task GetResultCount()
        {
            Count = await ((dynamic)_source).GetCountAsync();
        }


        public override String ToString()
        {
            return Description;
        }

        public String Name
        {
            get { return _name; }
            set { if (this.SetProperty(ref _name, value)) this.OnPropertyChanged("Description"); }
        }

        public DataTemplate ItemTemplate { get; private set; }

        public int Count
        {
            get { return _count; }
            set { if (this.SetProperty(ref _count, value)) this.OnPropertyChanged("Description"); }
        }

        public bool Active
        {
            get { return _active; }
            set { this.SetProperty(ref _active, value); }
        }

        public String Description
        {
            get { return String.Format("{0} ({1})", _name, _count); }
        }

        public virtual object GetSource()
        {
            return _source;
        }
    }
}