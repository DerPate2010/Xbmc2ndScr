namespace XBMCRPC.List.Item
{
   public class BaseFile : XBMCRPC.Video.Details.File,Base
   {
       public string album {get;set;}
       public string[] albumartist {get;set;}
       public int[] albumartistid {get;set;}
       public int albumid {get;set;}
       public string albumlabel {get;set;}
       public XBMCRPC.Video.Cast cast {get;set;}
       public string comment {get;set;}
       public string[] country {get;set;}
       public string description {get;set;}
       public int disc {get;set;}
       public int duration {get;set;}
       public int episode {get;set;}
       public string episodeguide {get;set;}
       public string firstaired {get;set;}
       public int id {get;set;}
       public string imdbnumber {get;set;}
       public string lyrics {get;set;}
       public string[] mood {get;set;}
       public string mpaa {get;set;}
       public string musicbrainzartistid {get;set;}
       public string musicbrainztrackid {get;set;}
       public string originaltitle {get;set;}
       public string plotoutline {get;set;}
       public string premiered {get;set;}
       public string productioncode {get;set;}
       public int season {get;set;}
       public string set {get;set;}
       public int setid {get;set;}
       public string[] showlink {get;set;}
       public string showtitle {get;set;}
       public string sorttitle {get;set;}
       public string[] studio {get;set;}
       public string[] style {get;set;}
       public string[] tag {get;set;}
       public string tagline {get;set;}
       public string[] theme {get;set;}
       public int top250 {get;set;}
       public int track {get;set;}
       public string trailer {get;set;}
       public int tvshowid {get;set;}
       public typeEnum type {get;set;}
       public global::System.Collections.Generic.Dictionary<string,string> uniqueid {get;set;}
       public string votes {get;set;}
       public int watchedepisodes {get;set;}
       public string[] writer {get;set;}
   }
   public class BaseMedia : XBMCRPC.Audio.Details.Media,Base
   {
       public string album {get;set;}
       public string[] albumartist {get;set;}
       public int[] albumartistid {get;set;}
       public int albumid {get;set;}
       public string albumlabel {get;set;}
       public XBMCRPC.Video.Cast cast {get;set;}
       public string comment {get;set;}
       public string[] country {get;set;}
       public string description {get;set;}
       public int disc {get;set;}
       public int duration {get;set;}
       public int episode {get;set;}
       public string episodeguide {get;set;}
       public string firstaired {get;set;}
       public int id {get;set;}
       public string imdbnumber {get;set;}
       public string lyrics {get;set;}
       public string[] mood {get;set;}
       public string mpaa {get;set;}
       public string musicbrainzartistid {get;set;}
       public string musicbrainztrackid {get;set;}
       public string originaltitle {get;set;}
       public string plotoutline {get;set;}
       public string premiered {get;set;}
       public string productioncode {get;set;}
       public int season {get;set;}
       public string set {get;set;}
       public int setid {get;set;}
       public string[] showlink {get;set;}
       public string showtitle {get;set;}
       public string sorttitle {get;set;}
       public string[] studio {get;set;}
       public string[] style {get;set;}
       public string[] tag {get;set;}
       public string tagline {get;set;}
       public string[] theme {get;set;}
       public int top250 {get;set;}
       public int track {get;set;}
       public string trailer {get;set;}
       public int tvshowid {get;set;}
       public typeEnum type {get;set;}
       public global::System.Collections.Generic.Dictionary<string,string> uniqueid {get;set;}
       public string votes {get;set;}
       public int watchedepisodes {get;set;}
       public string[] writer {get;set;}
   }
   public interface Base
   {
        string album {get;set;}
        string[] albumartist {get;set;}
        int[] albumartistid {get;set;}
        int albumid {get;set;}
        string albumlabel {get;set;}
        XBMCRPC.Video.Cast cast {get;set;}
        string comment {get;set;}
        string[] country {get;set;}
        string description {get;set;}
        int disc {get;set;}
        int duration {get;set;}
        int episode {get;set;}
        string episodeguide {get;set;}
        string firstaired {get;set;}
        int id {get;set;}
        string imdbnumber {get;set;}
        string lyrics {get;set;}
        string[] mood {get;set;}
        string mpaa {get;set;}
        string musicbrainzartistid {get;set;}
        string musicbrainztrackid {get;set;}
        string originaltitle {get;set;}
        string plotoutline {get;set;}
        string premiered {get;set;}
        string productioncode {get;set;}
        int season {get;set;}
        string set {get;set;}
        int setid {get;set;}
        string[] showlink {get;set;}
        string showtitle {get;set;}
        string sorttitle {get;set;}
        string[] studio {get;set;}
        string[] style {get;set;}
        string[] tag {get;set;}
        string tagline {get;set;}
        string[] theme {get;set;}
        int top250 {get;set;}
        int track {get;set;}
        string trailer {get;set;}
        int tvshowid {get;set;}
        typeEnum type {get;set;}
        global::System.Collections.Generic.Dictionary<string,string> uniqueid {get;set;}
        string votes {get;set;}
        int watchedepisodes {get;set;}
        string[] writer {get;set;}
   }
   public enum typeEnum
   {
       unknown,
       movie,
       episode,
       musicvideo,
       song,
       picture,
       channel,
   }
}
