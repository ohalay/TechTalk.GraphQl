using GraphQL.Types;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.GraphQl.Types
{
    public class ZombieInputType : InputObjectGraphType<Zombie>
    {
        public ZombieInputType()
        {
            Field(s => s.Name, nullable: true);
            Field(s => s.Location, nullable: true);
        }
    }
}