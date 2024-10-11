using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class UbicacionDto : BaseEntityDto
    {
        public string Descripcion { get; set; }
        public string Longitud {  get; set; }
        public string Latitud { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }

    }
}
