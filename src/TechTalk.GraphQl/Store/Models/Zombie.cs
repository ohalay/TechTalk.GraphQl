using System;

namespace TechTalk.GraphQl.Store.Models
{
    public class Zombie : IIdentifier
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
        
        public ZombieBreedTypes Type { get; set; }
    }
}