using System.Windows.Input;
using Okra.Core;
using Xbmc2S.RT.UPnP;

namespace Xbmc2S.Model
{
    public class PlayToVm
    {
        protected readonly PlayableItemVm _playableItem;
        private readonly MediaRendererDevice _renderer;

        public PlayToVm(PlayableItemVm playableItem, MediaRendererDevice renderer):this(playableItem)
        {
            _renderer = renderer;
            Label = renderer.FriendlyName;

        }

        protected PlayToVm(PlayableItemVm playableItem)
        {
            _playableItem = playableItem;
            Play = new DelegateCommand(PlayExecuted);            
        }

        protected virtual void PlayExecuted()
        {
            _playableItem.PlayTo(_renderer);
        }

        public string Label { get; protected set; }
        public ICommand Play { get; private set; }
    }

    public class PlayToLocalVm:PlayToVm
    {
        public PlayToLocalVm(PlayableItemVm playableItem):base(playableItem)
        {
            Label = "This device";
        }

        protected override void PlayExecuted()
        {
            _playableItem.PlayToLocal();
        }
    }
}