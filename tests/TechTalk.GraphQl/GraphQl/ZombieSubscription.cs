using GraphQL.Types;
using TechTalk.GraphQl.GraphQl.Types;
using TechTalk.GraphQl.Store;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl
{
    public class ZombieSubscription : ObjectGraphType
    {
        public ZombieSubscription(IZombieStore<Zombie> store)
        {
            FieldSubscribe<ZombieType>($"{nameof(Zombie)}sUpdated", resolve: ctx => ctx.Source, subscribe: ctx => store.Stream);
        }
    }
}