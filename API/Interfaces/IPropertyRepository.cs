using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IPropertyRepository
    {
        void Update(REProperty prop);
        Task<PropertyDto> Create(REProperty prop);
        Task<IEnumerable<PropertyDto>> GetPropertiesAsync();
        //Task<bool> IsExists(REProperty property);

    }
}