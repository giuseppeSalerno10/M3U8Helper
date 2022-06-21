using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Helper.Interfaces
{
    public interface IM3U8Reader
    {
        public Task<byte[]> GetSegmentBytes(string url);
        Task<string[]> GetPlaylistRecords(string url);
        public Task<string[]> GetVideoRecords(string url);
    }
}
