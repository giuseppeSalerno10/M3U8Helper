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
    public class SegmentsManager : ISegmentsManager
    {
        public SegmentsManager()
        {
        }

        public async Task<byte[]> DownloadSegment(PlaylistSegment segment, IM3U8Reader reader )
        {
            return await reader.GetSegmentBytes(segment.Url);
        }

        public async Task DownloadVideo(PlaylistSegment[] segments, string downloadPath, string fileName, IM3U8Reader reader)
        {
            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            if (File.Exists($"{downloadPath}/{fileName}"))
            {
                File.Delete($"{downloadPath}/{fileName}");
            }

            List<Task<byte[]>> downloads = new();

            foreach (var segment in segments)
            {
                downloads.Add(DownloadSegment(segment, reader));
            }

            foreach (var download in downloads)
            {
                var bytes = await download;

                using (var stream = new FileStream($"{downloadPath}/{fileName}", FileMode.Append))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
