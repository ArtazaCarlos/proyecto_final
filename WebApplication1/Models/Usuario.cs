namespace WebApplication1.Models
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string direccionCorreo { get; set; }
        public string cuil { get; set; }
        public Cargo cargo { get; set; }
        public string nombreUsuario { get; set; }
        public string contrasena { get; set; }
        public bool bloqueado { get; set; }
        public int? pinTemporal { get; set; }
        public DateTime ultimoAcceso { get; set; }
        //private List<Permiso> permisos;

        /*
        public int IdUsuario { get => idUsuario; set; }
        public string Apellidos { get => apellidos; }
        public string Nombres { get => nombres; }
        public string DireccionCorreo { get => direccionCorreo; }
        public string NombreUsuario { get => nombreUsuario; }
        public string Contrasena { get => contrasena; }
        public string Cuil { get => cuil; }
        public Cargo Cargo { get => cargo; set => cargo = value; }
        public bool Bloqueado { get => bloqueado; }
        public int? PinTemporal { get => pinTemporal; }
        public DateTime UltimoAcceso { get => ultimoAcceso; }
        //public List<Permiso> Permisos { get => permisos; }
        */

        public Usuario(int idUsuario, string apellidos, string nombres, string cuil, Cargo cargo, string direccionCorreo, string nombreUsuario, string contrasena, bool bloqueado, int pinTemporal, DateTime ultimoAcceso)
        {
            this.idUsuario = idUsuario;
            this.apellidos = apellidos;
            this.nombres = nombres;
            this.direccionCorreo = direccionCorreo;
            this.cuil = cuil;
            this.cargo = cargo;
            this.nombreUsuario = nombreUsuario;
            this.contrasena = contrasena;
            this.bloqueado = bloqueado;
            this.pinTemporal = pinTemporal;
            this.ultimoAcceso = ultimoAcceso;
        }

        public Usuario() { }

    }
}
