using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Helper.Models
{
    public class PlaylistModel
    {
        public string Url { get; set; } = null!;
        public PlaylistSegment[] Segments { get; set; } = null!;
        public PlaylistModelHeader Header { get; set; } = new();

    }

    public class PlaylistSegment
    {
        public string Url { get; set; } = null!;

    }

    public record PlaylistModelHeader
    {
        public string Version { get; set; } = null!;
        public string IsCacheAllowed { get; set; } = null!;
        public string MediaSequence { get; set; } = null!;
        public string PlaylistType { get; set; } = null!;
        public string TargetDuration { get; set; } = null!;
    }
}
