using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Dominio.Entidades;

namespace GoTrip.Aplicaciones.Mapper
{
    public class ReporteProfile : Profile
    {
        public ReporteProfile()
        {
            CreateMap<PuntoTuristicoMasVisitadoDTO, PuntoTuristicoMasVisitado>()
               .ReverseMap();

            CreateMap<PlanesPorMesDTO, PlanesPorMes>()
              .ReverseMap();
        }
       
    }
}
