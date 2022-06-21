using M3U8Helper.Interfaces;
using M3U8Helper.Manager;
using M3U8Helper.Manager.Interfaces;
using M3U8Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Helper
{
    public class M3U8Client : IM3U8Client
    {
        private readonly IVideosManager _videosManager;
        private readonly IPlaylistsManager _playlistManager;
        private readonly ISegmentsManager _segmentsManager;

        public IM3U8Reader M3U8Reader { get; set; }

        public M3U8Client(IVideosManager videosManager, IPlaylistsManager playlistManager, ISegmentsManager segmentsManager)
        {
            M3U8Reader = new M3U8Reader();
            _videosManager = videosManager;
            _playlistManager = playlistManager;
            _segmentsManager = segmentsManager;
        }


        public Task<VideoModel> GetVideoMetadata(string url)
        {
            return _videosManager.GetVideoMetadata(url, M3U8Reader);
        }

        public Task<PlaylistModel> GetPlaylistMetadata(string url)
        {
            return _playlistManager.GetPlaylistMetadata(url, M3U8Reader);
        }

        public Task DownloadVideo(PlaylistSegment[] segments, string downloadPath, string fileName)
        {
            return _segmentsManager.DownloadVideo(segments, downloadPath, fileName, M3U8Reader);
        }

        public Task<byte[]> DownloadSegment(PlaylistSegment segment)
        {
            return _segmentsManager.DownloadSegment(segment, M3U8Reader);
        }
    }
}
