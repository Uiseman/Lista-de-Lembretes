using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ListaDeLembretesAPI.Models;

namespace ListaDeLembretesAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lembrete, LembreteDTO>().ReverseMap();
        }
    }
}