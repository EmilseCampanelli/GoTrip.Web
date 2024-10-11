using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Mapper
{
    public class CaracteristicaProfile : Profile
    {
        public CaracteristicaProfile() 
        { 
            CreateMap<CaracteristicaDto, Caracteristica>().ReverseMap();
        }
    }
}
