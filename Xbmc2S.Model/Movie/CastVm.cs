
using System;
using TmdbWrapper;
using TmdbWrapper.Movies;
using KODIRPC.Video;

namespace Xbmc2S.Model
{
    public interface ICastVm
    {
        string Role { get; set; }
        string Name { get; }
        VideoImages Images { get; }
    }

    public class CastVm:BaseVM, ICastVm
    {
        private readonly CastItem _castItem;
        private readonly IAppContext _appContext;

        public CastVm(CastItem castItem, IAppContext appContext)
            : base(castItem.thumbnail,appContext)
        {
            _castItem = castItem;
            _appContext = appContext;
            Name=_castItem.name;
            Role=_castItem.role;
        }

        public string Role { get; set; }

        public string Name
        {
            get { return Label; }
            protected set { Label = value; }
        }
    }
    public class TmdbCast : BindableBase, ICastVm
    {

        public TmdbCast(CastPerson castItem, Config config)
        {
            Name=castItem.Name;
            Role=castItem.Character;

            Images = new VideoImages(new Uri( config.BaseUrlProfile + castItem.ProfilePath));
        }

        public string Role { get; set; }

        public string Name { get; set; }


        public VideoImages Images
        {
            get; private set;
        }
    }
}