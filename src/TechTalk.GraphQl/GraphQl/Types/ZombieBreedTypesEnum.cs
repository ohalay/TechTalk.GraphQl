using GraphQL.Types;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl.Types
{
    public class ZombieBreedTypesEnum : EnumerationGraphType<ZombieBreedTypes>
    {
        public ZombieBreedTypesEnum()
        {
            Name = nameof(ZombieBreedTypesEnum);
        }
    }
}