using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API.DTO;
using AutoMapper.QueryableExtensions;

namespace API.Data
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public PropertyRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<PropertyDto> Create(REProperty prop)
        {
              _context.Properties.Add(prop);
              await _context.SaveChangesAsync();

              return new PropertyDto{Id = prop.Id, Address = prop.Address, AccquisitionDate = prop.AccquisitionDate};
        }

        public async Task<IEnumerable<PropertyDto>> GetPropertiesAsync()
        {
            return await _context.Properties
            .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public void Update(REProperty prop)
        {
            _context.Entry(prop).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        //  Task<bool> IPropertyRepository.IsExists(REProperty property)
        // {
        //   return  _context.Properties.AnyAsync(x=> x.Address == property.Address && x.City == property.City && x.State == property.State && x.Zip == property.Zip);

        // }
    }
}