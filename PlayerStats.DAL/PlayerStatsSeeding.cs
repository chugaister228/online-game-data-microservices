using Bogus;
using PlayerStats.Data.Models;
using System;

namespace PlayerStats.DAL
{
    public static class PlayerStatsSeeding
    {
        public static List<Friend> Friends { get; set; } = new();
        public static List<Player> Players { get; set; } = new();
        public static List<Violation> Violations { get; set; } = new();

        public static void SeedingInit()
        {
            Friends = new Faker<Friend>()
                .RuleFor(x => x.Friendname, f => f.Person.UserName)
                .Generate(30);

            Players = new Faker<Player>()
                .RuleFor(x => x.Username, f => f.Person.UserName)
                .RuleFor(x => x.Wins, f => f.Random.Number(0, 500))
                .RuleFor(x => x.TotalGamesPlayed, f => f.Random.Number(0, 1000))
                .RuleFor(x => x.Rating, f => f.Random.Number(0, 5000))
                .Generate(30);

            Violations = new Faker<Violation>()
                .RuleFor(x => x.Type, f => f.Lorem.Word())
                .RuleFor(x => x.Description, f => f.Lorem.Word())
                .Generate(30);

            var playerIDs = Players.Select(x => x.ID).ToList();

            for (int i = 0; i < 30; i++)
            {
                var random = new Random();
                Friends[i].PlayerID = playerIDs[random.Next(playerIDs.Count)];
                Violations[i].PlayerID = playerIDs[random.Next(playerIDs.Count)];
            }
        }
    }
}
