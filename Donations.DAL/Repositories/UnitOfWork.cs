using Donations.DAL.Repositories.Interfaces;

namespace Donations.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DonationsContext databaseContext;
        public IDonationRepository DonationRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IUserRepository UserRepository { get; }

        public UnitOfWork(DonationsContext databaseContext, IDonationRepository donationRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            this.databaseContext = databaseContext;
            DonationRepository = donationRepository;
            ProductRepository = productRepository;
            UserRepository = userRepository;
        }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
