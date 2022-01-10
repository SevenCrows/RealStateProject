namespace RealState.Infrastructure.SQLDataAccess.Repositories
{
    using System;
    using System.Threading.Tasks;
    using RealState.Application.Repositories;
    using RealState.Domain.Model;

    public sealed class OwnerRepository : IOwnerReadRepository, IOwnerWriteRepository
    {
        private readonly RealstateContext realstateContext;

        public OwnerRepository(RealstateContext context)
        {
            this.realstateContext = context ?? throw new Exception(nameof(context));
        }

        public async Task Add(Owner owner)
        {
            Entities.Owner entity = new Entities.Owner
            {
                IdOwner = Guid.NewGuid(),
                Name = owner.Name,
                FirstSurname = owner.FirstSurname,
                SecondSurname = owner.SecondSurname,
                Address = owner.Address,
                Photo = owner.Photo,
                Birthday = owner.Birthday
            };

            await this.realstateContext.Owner.AddAsync(entity);
            await this.realstateContext.SaveChangesAsync();
        }

        public async Task<Owner> Get(Guid id)
        {
            Entities.Owner entity = await this.realstateContext
                .Owner
                .FindAsync(id);

            if (entity == null) return null;

            return new Owner
            {
                IdOwner = entity.IdOwner,
                Name = entity.Name,
                FirstSurname = entity.FirstSurname,
                SecondSurname = entity.SecondSurname,
                Address = entity.Address,
                Photo = entity.Photo,
                Birthday = entity.Birthday                
            };
        }

        public async Task Update(Owner owner)
        {
            Entities.Owner entity = new Entities.Owner
            {
                IdOwner = owner.IdOwner,
                Name = owner.Name,
                FirstSurname = owner.FirstSurname,
                SecondSurname = owner.SecondSurname,
                Address = owner.Address,
                Photo = owner.Photo,
                Birthday = owner.Birthday
            };

            this.realstateContext.Owner.Update(entity);
            await this.realstateContext.SaveChangesAsync();
        }
    }
}
