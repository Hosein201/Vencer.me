using Common;
using Common.CommonModel;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace Services
{
    public static class ElasticsearchExtensions
    {
        public static void AddElasticsearch(
            this IServiceCollection services, ElasticConfiguration configuration)
        {
            var url = configuration.Uri;  //var url = configuration["elasticsearch:url"];//localhost://9200
            var defaultIndex = configuration.Index;  //var defaultIndex = "businessurl";// configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex)
                .DefaultMappingFor<QueryBusinessDto>(m => m
                    .PropertyName(p => p.businessurl, "id")
                );


            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
