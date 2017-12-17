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
            CreateMap<Customer, CustomerDTO>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>();

            CreateMap<Movie, MovieDTO>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>();
        }
    }
}