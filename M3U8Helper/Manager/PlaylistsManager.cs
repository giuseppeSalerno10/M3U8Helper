using M3U8Helper.Interfaces;
using M3U8Helper.Manager.Interfaces;
using M3U8Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Helper.Manager
{
    public class PlaylistsManager : IPlaylistsManager
    {
        public PlaylistsManager()
        {
            
        }

        public async Task<PlaylistModel> GetPlaylistMetadata(string url, IM3U8Reader reader )
        {
            PlaylistModel playlistModel = new PlaylistModel() { Url = url };

            string[] records = await reader.GetPlaylistRecords(url);

            List<PlaylistSegment> playlistSegments = new List<PlaylistSegment>();

            for (int i = 0; i < records.Length; i++)
            {
                string? record = records[i];

                string[] splittedRecord = record.Split(":");

                switch (splittedRecord[0])
                {
                    case "#EXT-X-VERSION":
                        playlistModel.Header.Version = splittedRecord[1];
                        break;

                    case "#EXT-X-ALLOW-CACHE":
                        playlistModel.Header.IsCacheAllowed = splittedRecord[1];
                        break;

                    case "#EXT-X-TARGETDURATION":
                        playlistModel.Header.TargetDuration = splittedRecord[1];
                        break;

                    case "#EXT-X-MEDIA-SEQUENCE":
                        playlistModel.Header.MediaSequence = splittedRecord[1];
                        break;

                    case "#EXT-X-PLAYLIST-TYPE":
                        playlistModel.Header.PlaylistType = splittedRecord[1];
                        break;


                    case "#EXTINF":
                        var splittedUrl = url.Split("/");
                        splittedUrl[^1] = records[i + 1]
                            .Replace("./", "");

                        var segmentUri = string.Join("/", splittedUrl);

                        playlistSegments.Add(new PlaylistSegment
                        {
                            Url = segmentUri
                        });

                        i++;
                        break;
                }
            }

            playlistModel.Segments = playlistSegments.ToArray();

            return playlistModel;
        }

    }
}
