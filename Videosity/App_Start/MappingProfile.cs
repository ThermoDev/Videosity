using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videosity.DTO;
using Videosity.Models;

namespace Videosity.App_Start {
    public class MappingProfile : Profile {
        public MappingProfile() {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}