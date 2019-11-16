using System.Collections.Generic;
using TechTalk.GraphQl.Store.Models;

namespace TechTalk.GraphQl.Configuration
{
    public static class Const
    {
        public static readonly IReadOnlyCollection<ZombieBreed> ZombieBreedList = new[]
        {
            new ZombieBreed
            {
                Type = ZombieBreedTypes.Homer,
                Description = "Named after the dimwitted Homer from The Simpsons, these kinds of zombies are notoriously slow and stupid. They're easily distracted and comically inept."
            },
            new ZombieBreed
            {
                Type = ZombieBreedTypes.Hawking,
                Description = "Hawkings are the opposite of the Homers, and theoretically one of the more dangerous forms of zombies. Although they have all the speed, strength and durability of the normal zombie."
            },
            new ZombieBreed
            {
                Type = ZombieBreedTypes.Ninja,
                Description = "Like the Hawkings, Ninjas are relatively underutilized in the film. But in the introduction to what they can do they come across as one of the most terrifying forms of zombies."
            },
            new ZombieBreed 
            {
                Type = ZombieBreedTypes.T800,
                Description = "They also have fast enough reaction times to be able to dodge point-blank gunfire. What makes matters worse is that they have the endurance to survive more wounds than other zombies. They are even shown taking multiple bullets to the head... and still keep going. It takes the complete destruction of the skull to finally put one of these down."
            }
        };
    }
}