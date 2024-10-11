﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class PuntoTuristicoDto : BaseEntityDto
    {
        public string Descripcion { get; set; }

        public int CategoriaId { get; set; }
        public int UbicacionId { get; set; }
        public string PathImagen { get; set; }

    }
}
