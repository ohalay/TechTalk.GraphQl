using GraphQL.Types;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl.Types
{
    public class ZombieType : ObjectGraphType<Zombie>
    {
        public ZombieType()
        {
            Field(s => s.Id);
            Field(s => s.Name);
            Field(s => s.Location);
        }
    }
}