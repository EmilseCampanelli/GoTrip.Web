using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class RecorridoDto : BaseEntityDto
    {
        public int PlanViajeId {  get; set; }
        public List<int> PuntosTuristicos { get; set; }
        public List<int> Eventos {  get; set; }
    }
}
