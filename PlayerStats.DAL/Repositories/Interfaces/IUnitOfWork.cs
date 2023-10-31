using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerStats.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IFriendRepository FriendRepository { get; }
        IPlayerRepository PlayerRepository { get; }
        IViolationRepository ViolationRepository { get; }

        Task SaveChangesAsync();
    }
}
