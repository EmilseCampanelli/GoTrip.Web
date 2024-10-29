using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Contratos
{
    public interface ILineaRecorridoRepository : IRepository<LineaRecorrido>
    {
        Task SaveAll(List<LineaRecorrido> list);
        Task UpdateAll(List<LineaRecorrido> list);
    }
}
