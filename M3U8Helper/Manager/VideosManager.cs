using M3U8Helper.Interfaces;
using M3U8Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Helper.Manager
{
    public class VideosManager : IVideosManager
    {
        public VideosManager()
        {
        }

        public async Task<VideoModel> GetVideoMetadata(string url, IM3U8Reader reader)
        {
            VideoModel videoModel = new VideoModel() { Url = url};

            string[] records = await reader.GetVideoRecords(url);

            var streamInfosList = new List<VideoPlaylistInfosModel>();

            for (int i = 0; i < records.Length; i++)
            {
                string? record = records[i];

                string[] splittedRecord = record.Split(":");
                switch (splittedRecord[0])
                {
                    case "#EXT-X-VERSION":
                        videoModel.Version = splittedRecord[1];
                        break;

                    case "#EXT-X-STREAM-INF":
                        var urlSplitted = url.Split("/");
                        urlSplitted[^1] = records[i + 1]
                            .Replace("./", "");

                        var infoUri = string.Join("/", urlSplitted);

                        streamInfosList.Add(new VideoPlaylistInfosModel
                        {
                            Infos = splittedRecord[1],
                            Url = infoUri
                        });

                        i++;
                        break;
                    case "#EXT-X-MEDIA":
                        //streamInfosList.First().Infos = qualcosa;
                        break;
                }
            }

            videoModel.PlaylistInfos = streamInfosList.ToArray();

            return videoModel;
        }
    }
}
