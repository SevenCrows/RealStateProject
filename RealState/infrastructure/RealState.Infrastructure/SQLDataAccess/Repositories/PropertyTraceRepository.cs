using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealState.Application.Repositories;
using RealState.Domain.Model;

namespace RealState.Infrastructure.SQLDataAccess.Repositories
{
    public class PropertyTraceRepository : IPropertyTraceReadRepository, IPropertyTraceWriteRepository
    {
        private readonly RealstateContext realstateContext;

        public PropertyTraceRepository(RealstateContext context)
        {
            this.realstateContext = context ?? throw new Exception(nameof(context));
        }

        public async Task Add(PropertyTrace propertyTrace)
        {
            Entities.PropertyTrace entity = new Entities.PropertyTrace
            {
                IdPropertyTrace = Guid.NewGuid(),
                IdProperty = propertyTrace.IdProperty,
                Name = propertyTrace.Name,
                Value = propertyTrace.Value,
                DateSale = propertyTrace.DateSale,
                Tax = propertyTrace.Tax
            };
            await this.realstateContext.PropertyTrace.AddAsync(entity);
            await this.realstateContext.SaveChangesAsync();
        }

        public async Task<PropertyTrace> Get(Guid id)
        {
            Entities.PropertyTrace entity = await this.realstateContext
                .PropertyTrace
                .FindAsync(id);

            if (entity == null) return null;

            return new PropertyTrace
            {
                IdPropertyTrace = entity.IdPropertyTrace,
                IdProperty = entity.IdProperty,
                Name = entity.Name,
                Value = entity.Value,
                DateSale = entity.DateSale,
                Tax = entity.Tax
            };
        }

        public async Task Update(PropertyTrace propertyTrace)
        {
            Entities.PropertyTrace entity = new Entities.PropertyTrace
            {
                IdPropertyTrace = propertyTrace.IdPropertyTrace,
                IdProperty = propertyTrace.IdProperty,
                Name = propertyTrace.Name,
                Value = propertyTrace.Value,
                DateSale = propertyTrace.DateSale,
                Tax = propertyTrace.Tax
            };

            this.realstateContext.PropertyTrace.Update(entity);
            await this.realstateContext.SaveChangesAsync();
        }
    }
}
