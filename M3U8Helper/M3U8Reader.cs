using M3U8Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace M3U8Helper
{
    public class M3U8Reader : IM3U8Reader
    {
        public async Task<string[]> GetVideoRecords(string url)
        {
            string videoRawData = await GetHttpRawData(url, HttpMethod.Get);
            var data = videoRawData
                .Trim()
                .Replace("\r\n", "\n")
                .Split("\n");
            
            return data
                .Where( record => !string.IsNullOrEmpty(record))
                .ToArray();
        }

        public async Task<string[]> GetPlaylistRecords(string url)
        {
            string videoRawData = await GetHttpRawData(url, HttpMethod.Get);
            var data = videoRawData
                .Trim()
                .Replace("\r\n", "\n")
                .Split("\n");

            return data
                .Where(record => !string.IsNullOrEmpty(record))
                .ToArray();
        }

        public Task<byte[]> GetSegmentBytes(string url)
        {
            return GetHttpBytes(url, HttpMethod.Get);
        }

        private async Task<string> GetHttpRawData(string url, HttpMethod method, object? body = null)
        {
            var response = await SendAsync(url, method, body);
            return await response.Content.ReadAsStringAsync();
        }
        private async Task<byte[]> GetHttpBytes(string url, HttpMethod method, object? body = null)
        {
            var response = await SendAsync(url, method, body);
            return await response.Content.ReadAsByteArrayAsync();
        }

        private async Task<HttpResponseMessage> SendAsync(string url, HttpMethod method, object? body = null)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(method, url);

            if (body != null)
            {
                string serializedBody = JsonSerializer.Serialize(body);
                request.Content = new StringContent(serializedBody);
            }

            HttpResponseMessage response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
