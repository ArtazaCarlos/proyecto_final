namespace WebApplication1.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set;  }
        public string Sexo { get; set; }
        public string Dni {  get; set; }
        public string Cuil { get; set; }
        public string Cargo { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string DireccionCorreo { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Bloqueado { get; set; }
        public int? PINTemporal { get; set; }
        public DateTime UltimoAcceso { get; set; }

        public Usuario(int id, string apellidos, string nombres, string sexo, string dni, string cuil, string cargo, string domicilio, string telefono, string direccionCorreo, string nombreDeUsuario, string contrasena, bool bloqueado, int pINTemporal, DateTime ultimoAcceso)
        {
            Id = id;
            Apellidos = apellidos;
            Nombres = nombres;
            Sexo = sexo;
            Dni = dni;
            Cuil = cuil;
            Cargo = cargo;
            Domicilio = domicilio;
            Telefono = telefono;
            DireccionCorreo = direccionCorreo;
            NombreDeUsuario = nombreDeUsuario;
            Contrasena = contrasena;
            Bloqueado = bloqueado;
            PINTemporal = pINTemporal;
            UltimoAcceso = ultimoAcceso;
        }

        public Usuario() { }

        private string encriptarContrasena(string texto) { return "texto"; }
        public bool autenticar(string contrasena) { return true; }
        public void cambiarContrasena(string contrasena) { }
    }
}
