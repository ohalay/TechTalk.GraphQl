using GraphQL.Types;
using TechTalk.GraphQl.GraphQl.Types;
using TechTalk.GraphQl.Service;
using TechTalk.GraphQl.Store;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl
{
    public class ZombieMutation : ObjectGraphType
    {
        public ZombieMutation(IZombieStore<Zombie> store, IZombieBreedTypeGenerator zombieBreedTypeGenerator)
        {
            Field<ZombieType>($"Add{nameof(Zombie)}",
                arguments: new QueryArguments(
                    new QueryArgument<ZombieInputType> { Name = "model" }
                ),
                resolve: context =>
                {
                    var zombie = context.GetArgument<Zombie>("model");
                    zombie.Type = zombieBreedTypeGenerator.Generate();

                    store.Add(zombie);

                    return zombie;
                });
        }
    }
}