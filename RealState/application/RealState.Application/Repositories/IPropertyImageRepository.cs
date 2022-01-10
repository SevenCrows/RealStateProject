namespace RealState.Application.Repositories
{
    using System;
    using System.Threading.Tasks;
    using RealState.Domain.Model;

    public interface IPropertyImageReadRepository
    {
        Task<PropertyImage> Get(Guid id);
    }

    public interface IPropertyImageWriteRepository
    {
        Task Add(PropertyImage propertyImage);
        Task Update(PropertyImage propertyImage);        
    }
}
