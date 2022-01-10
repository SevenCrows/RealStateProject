namespace RealState.Infrastructure.SQLDataAccess.Repositories
{
    using System;
    using System.Threading.Tasks;
    using RealState.Application.Repositories;
    using RealState.Domain.Model;

    public class PropertyRepository : IPropertyReadRepository, IPropertyWriteRepository
    {
        private readonly RealstateContext realstateContext;

        public PropertyRepository(RealstateContext context)
        {
            this.realstateContext = context ?? throw new Exception(nameof(context));
        }

        public async Task Add(Property property)
        {
            Entities.Property entity = new Entities.Property
            {
                IdProperty = Guid.NewGuid(),
                Name = property.Name,
                Address = property.Address,
                CodeInternal = property.CodeInternal,
                Price = property.Price,
                Year = property.Year,
                IdOwner = property.IdOwner
            };
            await this.realstateContext.Property.AddAsync(entity);
            await this.realstateContext.SaveChangesAsync();
        }

        public async Task<Property> Get(Guid id)
        {
            Entities.Property entity = await this.realstateContext
                .Property
                .FindAsync(id);

            if (entity == null) return null;

            return new Property
            {
                IdProperty = entity.IdProperty,
                Name = entity.Name,
                Address = entity.Address,
                CodeInternal = entity.CodeInternal,
                Price = entity.Price,
                Year = entity.Year,
                IdOwner = entity.IdOwner                
            };
        }

        public async Task Update(Property property)
        {
            Entities.Property entity = new Entities.Property
            {
                IdProperty = property.IdProperty,
                Name = property.Name,
                Address = property.Address,
                CodeInternal = property.CodeInternal,
                Price = property.Price,
                Year = property.Year,
                IdOwner = property.IdOwner
            };

            this.realstateContext.Property.Update(entity);
            await this.realstateContext.SaveChangesAsync();
        }
    }
}
