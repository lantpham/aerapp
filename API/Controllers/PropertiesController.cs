using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
    public class PropertiesController : BaseApiController
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PropertiesController(IPropertyRepository repository, IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _repository = repository;
             _context = context;
        }
        // private readonly DataContext _context;
        // private readonly IMapper _mapper;
        // public PropertiesController(DataContext context, IMapper mapper)
        // {
        //     _context = context;
        //     _mapper = mapper;

        // }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<REProperty>>> GetProperties()
        {
            var props = await _repository.GetPropertiesAsync();
            // var props = await _context.Properties
            // .ToListAsync();
            return Ok(props);
        }

        [HttpPost("create")]
        public async Task<ActionResult<PropertyDto>> CreateProperty(PropertyDto propDto)
        {
            var prop = new REProperty
            {
                FromUserName = "",
                Address = propDto.Address,
                City = propDto.City,
                State = propDto.State,
                Zip = propDto.Zip,
                AccquisitionDate = propDto.AccquisitionDate,
                AccquisitionValue = propDto.AccquisitionValue,
                CreatedDate = DateTime.Now
            };
            _context.Properties.Add(prop);
            return Ok(await _context.SaveChangesAsync());
            //return Ok(await _repository.CreateAsync(prop));
        }

    }
}