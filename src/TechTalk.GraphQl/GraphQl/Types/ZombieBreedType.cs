using GraphQL.Types;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl.Types
{
    public class ZombieBreedType : ObjectGraphType<ZombieBreed>
    {
        public ZombieBreedType()
        {
            Field(s => s.Type, type: typeof(ZombieBreedTypesEnum));
            Field(s => s.Description);
        }
    }
}