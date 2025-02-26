using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository _reporteRepository;
        private readonly IMapper _mapper;

        public ReporteService(IReporteRepository reporteRepository, IMapper mapper)
        {
            _reporteRepository = reporteRepository;
            _mapper = mapper;
        }


        public ReporteDto ObtenerReporte()
        {
            var reporteDto = new ReporteDto();

            reporteDto.PuntosMasVisitados = _mapper.Map<List<PuntoTuristicoMasVisitadoDTO>>(_reporteRepository.GetPuntoTuristicoMasVisitado());
            reporteDto.CantPlanesDeViaje = _mapper.Map<List<PlanesPorMesDTO>>(_reporteRepository.CantidadPlanesViajesRealizados());
            reporteDto.CantUsuariosVidentesActivos = _reporteRepository.CantidadUsuariosVidentesActivos();
            reporteDto.CantUsuariosNoVidentesActivos = _reporteRepository.CantidadUsuariosNoVidentesActivos();

            return reporteDto;
        }
    }
}
