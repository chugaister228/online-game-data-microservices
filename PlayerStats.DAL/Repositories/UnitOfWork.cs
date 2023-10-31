using PlayerStats.DAL.Repositories.Interfaces;

namespace PlayerStats.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly PlayerStatsContext databaseContext;
        public IFriendRepository FriendRepository { get; }
        public IPlayerRepository PlayerRepository { get; }
        public IViolationRepository ViolationRepository { get; }

        public UnitOfWork(PlayerStatsContext databaseContext, IFriendRepository friendRepository, IPlayerRepository playerRepository, IViolationRepository violationRepository)
        {
            this.databaseContext = databaseContext;
            FriendRepository = friendRepository;
            PlayerRepository = playerRepository;
            ViolationRepository = violationRepository;
        }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
