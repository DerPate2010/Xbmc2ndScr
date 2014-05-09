using Windows.UI.Xaml.Controls;
using XBMCRPC.Video;

namespace Xbmc2S.RT.Model
{
    class CastVm:BaseVM
    {
        private readonly CastItem _castItem;
        private readonly IServerInfo _server;

        public CastVm(CastItem castItem, IServerInfo server)
            : base(castItem.thumbnail,server)
        {
            _castItem = castItem;
            _server = server;
            Name=_castItem.name;
            Role=_castItem.role;
        }

        public string Role { get; set; }

        public string Name
        {
            get { return Label; }
            protected set { Label = value; }
        }

        public override void NavigateToDetails(Frame frame)
        {
            MainVm.Current.Search(this);
            frame.Navigate(typeof(MovieOverviewPage));
        }
    }
}