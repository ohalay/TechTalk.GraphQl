using System;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.Service
{
    public class ZombieBreedTypeGenerator : IZombieBreedTypeGenerator
    {
        private static readonly Random random = new Random();

        public ZombieBreedTypes Generate()
        {
            var types = Enum.GetValues(typeof(ZombieBreedTypes));

            return (ZombieBreedTypes)types.GetValue(random.Next(types.Length));
        }
    }
}