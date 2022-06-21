using M3U8Helper.Interfaces;
using M3U8Helper.Manager;
using M3U8Helper.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3U8Helper
{
    public static class M3U8Extensions
    {
        public static IServiceCollection AddM3U8Services(this IServiceCollection services)
        {
            services
                .AddSingleton<IM3U8Client, M3U8Client>()

                // Managers
                .AddSingleton<IVideosManager, VideosManager>()
                .AddSingleton<IPlaylistsManager, PlaylistsManager>()
                .AddSingleton<ISegmentsManager, SegmentsManager>();

            return services;
        }
    }
}
