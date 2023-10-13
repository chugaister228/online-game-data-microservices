using Skins.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skins.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly SkinsContext databaseContext;
        public ICharacterRepository CharacterRepository { get; }
        public IPetRepository PetRepository { get; }
        public IWeaponRepository WeaponRepository { get; }

        public UnitOfWork(SkinsContext databaseContext, ICharacterRepository characterRepository, IPetRepository petRepository, IWeaponRepository weaponRepository)
        {
            this.databaseContext = databaseContext;
            CharacterRepository = characterRepository;
            PetRepository = petRepository;
            WeaponRepository = weaponRepository;
        }

        public async Task SaveChangesAsync()
        {
            await databaseContext.SaveChangesAsync();
        }
    }
}
