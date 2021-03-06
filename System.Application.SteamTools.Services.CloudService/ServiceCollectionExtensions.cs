﻿using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Application.Services;
using System.Application.Services.CloudService;
using System.Net;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 尝试添加 CloudServiceClient
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection TryAddCloudServiceClient<T>(this IServiceCollection services)
            where T : CloudServiceClientBase
        {
            services.TryAddHttpPlatformHelper();
            services.AddHttpClient(CloudServiceClientBase.ClientName_, (s, c) =>
            {
                var sc = s.GetRequiredService<CloudServiceClientBase>();
                c.BaseAddress = new Uri(sc.ApiBaseUrl);
                c.DefaultRequestHeaders.UserAgent.ParseAdd(sc.UserAgent);
                c.DefaultRequestHeaders.Add(Constants.Headers.Request.AppVersion, sc.Settings.AppVersion.ToStringN());
#if NET5_0_OR_GREATER
                c.DefaultRequestVersion = HttpVersion.Version20;
#endif
            });
            services.TryAddSingleton<T>();
            services.TryAddSingleton<ICloudServiceClient>(s => s.GetRequiredService<T>());
            services.TryAddSingleton<CloudServiceClientBase>(s => s.GetRequiredService<T>());
            return services;
        }
    }
}