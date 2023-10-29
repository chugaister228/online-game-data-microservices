using Bogus;
using Donations.Data.Models;

namespace Donations.DAL
{
    public static class DonationsSeeding
    {
        public static List<Donation> Donations { get; set; } = new();
        public static List<Product> Products { get; set; } = new();
        public static List<User> Users { get; set; } = new();

        public static void SeedingInit()
        {
            Donations = new Faker<Donation>()
                .RuleFor(x => x.Sum, f => f.Random.Number(1000))
                .RuleFor(x => x.Date, f=> f.Date.Past())
                .Generate(30);

            Products = new Faker<Product>()
                .RuleFor(x => x.Name, f => f.Lorem.Word())
                .Generate(30);

            Users = new Faker<User>()
                .RuleFor(x => x.Username, f => f.Person.UserName)
                .RuleFor(x => x.CreditCardNumber, f => f.Finance.CreditCardNumber())
                .Generate(30);

            var productIDs = Products.Select(x => x.ID).ToList();
            var userIDs = Users.Select(x => x.ID).ToList();

            for(int i = 0; i < Donations.Count; i++)
            {
                var random = new Random();

                Donations[i].ProductID = productIDs[random.Next(productIDs.Count)];
                Donations[i].UserID = userIDs[random.Next(productIDs.Count)];
            }
        }
    }
}
