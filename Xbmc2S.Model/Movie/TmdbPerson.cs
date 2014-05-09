using System;
using TmdbWrapper;
using TmdbWrapper.Persons;
using TmdbWrapper.Search;

namespace Xbmc2S.Model
{
    public class TmdbPerson
    {
        public TmdbPerson(Config config, PersonSummary summary)
        {
            Image=new Uri(config.BaseUrlProfile + summary.ProfilePath);
            Label = summary.Name;
        }

        public TmdbPerson(Config config, Person details)
        {
            Image = new Uri(config.BaseUrlProfile + details.ProfilePath);
            Label = details.Name;
            Content=details.Biography;
        }

        public object Image { get; private set; }
        public string Label { get; private set; }
        public string SecondLabel { get; private set; }
        public bool WatchedCheck { get; private set; }
        public string Content { get; private set; }
    }
}