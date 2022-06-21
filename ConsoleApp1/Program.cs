using M3U8Helper;
using M3U8Helper.Interfaces;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddM3U8Services()
     )
    .Build();

var client = (IM3U8Client) host.Services.GetService(typeof(IM3U8Client))!;

//var url = "https://www.saturnspeed29.org/DDL/ANIME/JujutsuKaisen/01/playlist.m3u8";
var url = "https://scws.xyz/master/72617?token=5mkzlJUCWxsfJvOmVXRRBw&expires=1655979330";

var video = await client.GetVideoMetadata(url);

var playlist = await client.GetPlaylistMetadata(video.PlaylistInfos[0].Url);


var animeUnitySegment = await client.DownloadSegment(playlist.Segments[0]);
await client.DownloadVideo(playlist.Segments, "C:\\Users\\Giuse\\Desktop", "playlist.mp4");

var a = 1;