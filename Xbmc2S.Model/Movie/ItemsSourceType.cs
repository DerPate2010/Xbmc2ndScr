namespace Xbmc2S.Model
{
    public enum ItemsSourceType
    {
        Movie,
        WatchList,
        Extern,
        Cast,
        TVShow,
        Episode,
        Season
    }

    public enum ItemsSourceFilter
    {
        All,Id,Cast,Title,
        Genre,
        Tag,
        FullText,
    }
}