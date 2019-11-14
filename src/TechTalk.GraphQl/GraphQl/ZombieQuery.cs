using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL.Types;
using TechTalk.GraphQl.GraphQl.Types;
using TechTalk.GraphQl.Store;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl
{
    public class ZombieQuery : ObjectGraphType
    {
        public ZombieQuery(IZombieStore<Zombie> store)
        {
            FieldAsync<ListGraphType<ZombieType>, IReadOnlyCollection<Zombie>>($"{nameof(Zombie)}s", resolve: context => store.GetAll().AsTask());
        }
    }
}