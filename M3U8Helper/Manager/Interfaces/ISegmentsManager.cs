using M3U8Helper.Interfaces;
using M3U8Helper.Models;

namespace M3U8Helper.Manager.Interfaces
{
    public interface ISegmentsManager
    {
        Task<byte[]> DownloadSegment(PlaylistSegment segment, IM3U8Reader reader);
        Task DownloadVideo(PlaylistSegment[] segments, string downloadPath, string fileName, IM3U8Reader reader);
    }
}