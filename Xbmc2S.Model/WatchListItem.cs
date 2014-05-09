using System.Runtime.Serialization;

namespace Xbmc2S.Model
{
    [DataContract]
    public class WatchListItem:BindableBase
    {

        public WatchListItem(PlayableItemVm item)
        {

            Label = item.Label;
            Id = item.Id;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Label { get; set; }

    }
}