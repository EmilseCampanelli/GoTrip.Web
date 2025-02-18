using GoTrip.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GoTrip.Datos.Context
{
    public class GoTripContext : DbContext
    {
        public GoTripContext(DbContextOptions<GoTripContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PuntoTuristico>()
                .Navigation(e => e.Categoria)
                .AutoInclude();
            modelBuilder.Entity<PuntoTuristico>()
                .Navigation(e => e.Ubicacion)
                .AutoInclude();
            modelBuilder.Entity<PuntoTuristico>()
                .Navigation(e => e.Usuario)
                .AutoInclude();
            modelBuilder.Entity<Evento>()
               .Navigation(e => e.Categoria)
               .AutoInclude();
            modelBuilder.Entity<Evento>()
                .Navigation(e => e.Ubicacion)
                .AutoInclude();
            modelBuilder.Entity<Evento>()
                .Navigation(e => e.Usuario)
                .AutoInclude();

            modelBuilder.Entity<PlanViaje>()
                .Navigation(e => e.LineaPuntos)
                .AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Permiso> Permisos { get; set; }

        public DbSet<Recorrido> Recorridos { get; set; }

        public DbSet<Ubicacion> Ubicaciones { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<PuntoTuristico> PuntosTuristicos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<PlanViaje> PlanViajes { get; set; }

        public DbSet<LineaPlanViaje> LineaPuntoTuristicos { get; set; }

    }
}
