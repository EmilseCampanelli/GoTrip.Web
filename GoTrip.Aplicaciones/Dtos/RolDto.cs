using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class RolDto : BaseEntityDto
    {
        public string Descripcion { get; set; }
        public List<int> Permisos { get; set; }

    }
}
