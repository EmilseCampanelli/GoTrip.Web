using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class EventoDto : BaseEntityDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {get; set; }
        public string? PathImagen { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDto? Categoria { get; set; }
        //public List<ComentarioDto>? Comentarios { get; set; }

    }
}
