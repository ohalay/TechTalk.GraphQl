using GraphQL.Server.Authorization.AspNetCore;
using GraphQL.Types;
using System.Collections.Generic;
using TechTalk.GraphQl.Configuration;
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
            Field<ListGraphType<ZombieBreedType>>($"{nameof(ZombieBreed)}s", resolve: context => Const.ZombieBreedList)
                .AuthorizeWith(Const.AuthorizedPolicy);
        }
    }
}