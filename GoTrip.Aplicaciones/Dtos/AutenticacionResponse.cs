using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class AutenticacionResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsNoVidente { get; set; }
    }
}
