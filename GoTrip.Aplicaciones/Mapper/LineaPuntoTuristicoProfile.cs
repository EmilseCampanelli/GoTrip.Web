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
    public class LineaPuntoTuristicoProfile : Profile
    {
        public LineaPuntoTuristicoProfile()
        {
            CreateMap<LineaPuntoTuristicoDto, LineaPuntoTuristico>().ReverseMap();
        }
    }
}
