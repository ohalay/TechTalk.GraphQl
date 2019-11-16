using GraphQL.DataLoader;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.GraphQl.Configuration;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl.Types
{
    public class ZombieType : ObjectGraphType<Zombie>
    {
        public ZombieType(IDataLoaderContextAccessor accessor)
        {
            Field(s => s.Id);
            Field(s => s.Name);
            Field(s => s.Location);
            FieldAsync<ZombieBreedType, ZombieBreed>(name: nameof(ZombieBreed), resolve: ctx =>
            {

                var zombieBreedLoader = accessor.Context
                    .GetOrAddBatchLoader<ZombieBreedTypes, ZombieBreed>("GetZombieBreedByType", GetZombieBreeds);

                return zombieBreedLoader.LoadAsync(ctx.Source.Type);

                Task<IDictionary<ZombieBreedTypes, ZombieBreed>> GetZombieBreeds(IEnumerable<ZombieBreedTypes> typse)
                {
                    var result = Const.ZombieBreedList
                        .Where(s => typse.Contains(s.Type))
                        .ToDictionary(s => s.Type, s => s);

                    return Task.FromResult<IDictionary<ZombieBreedTypes, ZombieBreed>>(result);
                }
            });
        }
    }
}