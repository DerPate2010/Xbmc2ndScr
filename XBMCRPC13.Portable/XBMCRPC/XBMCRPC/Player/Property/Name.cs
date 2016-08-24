using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
#pragma warning disable CS0108

namespace XBMCRPC.Player.Property
{
   public enum Name
   {
       type,
       partymode,
       speed,
       time,
       percentage,
       totaltime,
       playlistid,
       position,
       repeat,
       shuffled,
       canseek,
       canchangespeed,
       canmove,
       canzoom,
       canrotate,
       canshuffle,
       canrepeat,
       currentaudiostream,
       audiostreams,
       subtitleenabled,
       currentsubtitle,
       subtitles,
       live,
   }
}
