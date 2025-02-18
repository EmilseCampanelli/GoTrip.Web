namespace GoTrip.Dominio.Entidades
{
    public class Recorrido : BaseEntity
    {
        public int PlanViajeId { get; set; }
        public virtual PlanViaje PlanViaje { get; set; }

        //Lista de LineaPlanViaje
    }
}
