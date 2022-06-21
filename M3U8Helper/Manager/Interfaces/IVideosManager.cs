using M3U8Helper.Interfaces;
using M3U8Helper.Models;

namespace M3U8Helper.Manager
{
    public interface IVideosManager
    {
        Task<VideoModel> GetVideoMetadata(string url, IM3U8Reader m3U8Reader );
    }
}