namespace RealState.Application.Repositories
{
    using System;
    using System.Threading.Tasks;
    using RealState.Domain.Model;

    public interface IPropertyTraceReadRepository
    {
        Task<PropertyTrace> Get(Guid id);
    }

    public interface IPropertyTraceWriteRepository
    {
        Task Add(PropertyTrace propertyTrace);
        Task Update(PropertyTrace propertyTrace);
    }
}
