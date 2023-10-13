using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICharacterRepository CharacterRepository { get; }
        IPetRepository PetRepository { get; }
        IWeaponRepository WeaponRepository { get; }

        Task SaveChangesAsync();
    }
}
