using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using TechTalk.GraphQl.GraphQl;
using TechTalk.GraphQl.GraphQl.Types;
using TechTalk.GraphQl.Store;

namespace TechTalk.GraphQl
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(typeof(IZombieStore<>), typeof(MemoryStore<>))
                .AddSingleton<ISchema, ZombieSchema>();
           
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true /*environment.IsDevelopment()*/;
                    options.UnhandledExceptionDelegate += context =>
                    {
                        Debug.WriteLine(context.Exception);
                    };
                })
                .AddGraphTypes(typeof(ZombieType).Assembly)
                .AddWebSockets()
                .AddDataLoader();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseWebSockets();

            app.UseGraphQLWebSockets<ISchema>()
                .UseGraphQL<ISchema>()
                .UseGraphQLPlayground(new GraphQLPlaygroundOptions())
                .UseGraphQLVoyager(new GraphQLVoyagerOptions());
        }
    }
}