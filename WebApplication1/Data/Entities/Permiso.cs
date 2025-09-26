namespace WebApplication1.Data.Entities
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public string PermisoName { get; set; }

        public Permiso()
        {
        }

        public Permiso(int idPermiso, string permisoName)
        {
            IdPermiso = idPermiso;
            PermisoName = permisoName;
        }
    }
}
