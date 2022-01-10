namespace RealState.Application.Repositories
{
    using System;
    using System.Threading.Tasks;
    using RealState.Domain.Model;

    public interface IPropertyReadRepository
    {
        Task<Property> Get(Guid id);
    }

    public interface IPropertyWriteRepository
    {
        Task Add(Property property);
        Task Update(Property property);
    }
}
