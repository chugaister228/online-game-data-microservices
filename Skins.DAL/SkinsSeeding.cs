using Skins.Data.Models;
using Bogus;

namespace Skins.DAL
{
    public static class SkinsSeeding
    {
        public static List<Character> Characters { get; set; } = new();
        public static List<Pet> Pets { get; set; } = new();
        public static List<Weapon> Weapons { get; set; } = new();

        public static void SeedingInit()
        {
            Characters = new Faker<Character>()
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.Rarity, f => f.Random.Number(5))
                .RuleFor(x => x.RaceOfCharacter, f => f.Lorem.Word())
                .Generate(30);

            Pets = new Faker<Pet>()
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.Rarity, f => f.Random.Number(5))
                .RuleFor(x => x.KindOfAnimal, f => f.Lorem.Word())
                .Generate(30);

            Weapons = new Faker<Weapon>()
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.Rarity, f => f.Random.Number(5))
                .RuleFor(x => x.TypeOfWeapon, f => f.Lorem.Word())
                .Generate(30);

            var characterIDs = Characters.Select(x => x.ID).ToList();

            for(int i = 0; i < 30; i++)
            {
                Pets[i].CharacterID = characterIDs[i];
                Weapons[i].CharacterID = characterIDs[i];
            }
        }
    }
}
