using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace TechTalk.GraphQl.GraphQl
{
    public class ZombieSchema : Schema
    {
        public ZombieSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetService<ZombieQuery>();
            Mutation = provider.GetService<ZombieMutation>();
            Subscription = provider.GetService<ZombieSubscription>();
        }
    }
}