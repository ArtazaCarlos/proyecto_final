using System.Security.Cryptography;
using System.Text;


namespace WebApplication1.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public string Dni { get; set; }
        public Cargo Cargo { get; set; }
        public string Cuil { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string DireccionCorreo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime FechaHoraUltConectado { get; set; }
        public short? PinTemporal { get; set; }
        public bool Activo { get; set; }
        public List<Permiso> Permisos { get; set; } = new List<Permiso>();


        public Usuario()
        {
        }

        public Usuario(int idUsuario, string apellidos, string nombres, string sexo, string dni, Cargo cargo, string cuil, string domicilio, string telefono, string direccionCorreo, string nombreUsuario, string contrasena)
        {
            IdUsuario = idUsuario;
            Apellidos = apellidos;
            Nombres = nombres;
            Sexo = sexo;
            Dni = dni;
            Cargo = cargo;
            Cuil = cuil;
            Domicilio = domicilio;
            Telefono = telefono;
            DireccionCorreo = direccionCorreo;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Bloqueado = false;
            FechaHoraUltConectado = DateTime.Now;
            PinTemporal = null;
            Activo = true;
        }
    }
}
