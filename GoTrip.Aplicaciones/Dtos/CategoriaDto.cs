using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class CategoriaDto : BaseEntityDto
    {
        public string Descripcion { get; set; }
        public List<int> Categorias { get; set; }
    }
}
