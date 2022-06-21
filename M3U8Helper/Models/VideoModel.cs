using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Helper.Models
{
    public class VideoModel
    {
        public string Version { get; set; } = null!;
        public string Url { get; set; } = null!;
        public VideoInfoModel? Infos {get;set;}
        public VideoPlaylistInfosModel[] PlaylistInfos { get; set; } = null!; 
    }

    public class VideoInfoModel
    {
        public string Subtitles { get; set; } = null!;
    }

    public class VideoPlaylistInfosModel
    {
        public string Infos { get; set; } = null!;
        public string Url { get; set; } = null!;
    }
}
