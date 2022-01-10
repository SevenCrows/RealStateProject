namespace RealState.Infrastructure.SQLDataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RealState.Application.Repositories;
    using RealState.Domain.Model;

    public class PropertyImageRepository : IPropertyImageReadRepository, IPropertyImageWriteRepository
    {
        private readonly RealstateContext realstateContext;

        public PropertyImageRepository(RealstateContext context)
        {
            this.realstateContext = context ?? throw new Exception(nameof(context));
        }

        public async Task Add(PropertyImage propertyImage)
        {
            Entities.PropertyImage entity = new Entities.PropertyImage
            {                
                IdPropertyImage = Guid.NewGuid(),
                IdProperty = propertyImage.IdProperty,
                File = propertyImage.File
            };

            await this.realstateContext.PropertyImage.AddAsync(entity);
            await this.realstateContext.SaveChangesAsync();
        }

        public async Task<PropertyImage> Get(Guid id)
        {
            Entities.PropertyImage entity = await this.realstateContext
                 .PropertyImage
                 .FindAsync(id);

            if (entity == null) return null;

            return new PropertyImage
            {
                IdPropertyImage = entity.IdPropertyImage,
                IdProperty = entity.IdProperty,
                File = entity.File,
                Enabled = entity.Enabled
            };
        }

        public async Task Update(PropertyImage propertyImage)
        {
            Entities.PropertyImage entity = new Entities.PropertyImage
            {
                IdPropertyImage = propertyImage.IdPropertyImage,
                IdProperty = propertyImage.IdProperty,
                File = propertyImage.File,
                Enabled = propertyImage.Enabled
            };
            this.realstateContext.PropertyImage.Update(entity);
            await this.realstateContext.SaveChangesAsync();
        }
    }
}
