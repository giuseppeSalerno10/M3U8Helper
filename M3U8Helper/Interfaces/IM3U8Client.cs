using M3U8Helper.Models;

namespace M3U8Helper.Interfaces
{
    public interface IM3U8Client
    {
        Task<byte[]> DownloadSegment(PlaylistSegment segment);
        Task DownloadVideo(PlaylistSegment[] segments, string downloadPath, string fileName);
        Task<PlaylistModel> GetPlaylistMetadata(string url);
        Task<VideoModel> GetVideoMetadata(string url);
    }
}