#define NETCOREAPP3_0

using GraphQL.Server;
using GraphQL.Server.Authorization.AspNetCore;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TechTalk.GraphQl.Configuration;
using TechTalk.GraphQl.GraphQl;
using TechTalk.GraphQl.GraphQl.Types;
using TechTalk.GraphQl.Service;
using TechTalk.GraphQl.Store;

namespace TechTalk.GraphQl
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = Configuration.Get<Config>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                 {
                     option.Audience = config.ClientId;
                     option.Authority = $"{config.Instance}/{config.TenantId}/v2.0";
                     option.TokenValidationParameters = new TokenValidationParameters
                     {
                         RoleClaimType = ClaimTypes.Role,
                         ValidateAudience = true,
                         ValidateIssuer = true,
                     };
                 });

            services.AddHttpContextAccessor()
                .AddTransient<IValidationRule, AuthorizationValidationRule>()
                .AddAuthorizationCore(option => 
                {
                    option.AddPolicy(Const.AuthorizedPolicy, p => p.RequireAuthenticatedUser());
                })
                .AddGraphQL()
                .AddGraphTypes(typeof(ZombieType).Assembly)
                .AddWebSockets()
                .AddDataLoader();

            services
                .AddSingleton(typeof(IZombieStore<>), typeof(MemoryStore<>))
                .AddSingleton<IZombieBreedTypeGenerator, ZombieBreedTypeGenerator>()
                .AddSingleton<ISchema, ZombieSchema>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseWebSockets();

            app.UseGraphQLWebSockets<ISchema>()
                .UseGraphQL<ISchema>()
                .UseGraphQLPlayground(new GraphQLPlaygroundOptions())
                .UseGraphQLVoyager(new GraphQLVoyagerOptions());
        }
    }
}