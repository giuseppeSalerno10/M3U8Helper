using M3U8Helper.Interfaces;
using M3U8Helper.Models;

namespace M3U8Helper.Manager.Interfaces
{
    public interface IPlaylistsManager
    {
        Task<PlaylistModel> GetPlaylistMetadata(string url, IM3U8Reader reader);
    }
}