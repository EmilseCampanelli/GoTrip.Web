using GoTrip.Dominio.Entidades;

namespace GoTrip.Aplicaciones.Helper
{
    public static class BaseEntityHelper
    {
        public static void SetCreated<T>(T entity, int userId)
            where T : BaseEntity
        {
            entity.CreatedDate = DateTime.Now;
            entity.State = Dominio.Enums.BaseState.Activo;
            entity.UsuarioId = userId;
        }

        public static void SetUpdated<T>(T entity, int userId)
            where T : BaseEntity
        {
            entity.UpdatedDate = DateTime.Now;
            entity.UsuarioId = userId;
        }

        public static void SetActive<T>(T entity, int userId)
            where T : BaseEntity
        {
            entity.State = Dominio.Enums.BaseState.Activo;
            entity.UpdatedDate = DateTime.Now;
            entity.UsuarioId = userId;
        }

        public static void SetInactive<T>(T entity, int userId)
            where T : BaseEntity
        {
            entity.State = Dominio.Enums.BaseState.Inactivo;
            entity.UpdatedDate = DateTime.Now;
            entity.UsuarioId = userId;
        }
    }
}
