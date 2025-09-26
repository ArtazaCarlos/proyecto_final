using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class UsuarioListarVM
    {
        public int idUsuario { get; set; }
        public string apellidos { get; set; }
        public string nombres { get; set; }
        public string direccionCorreo { get; set; }
        public string cuil { get; set; }
        public Cargo cargo { get; set; }
        public string nombreUsuario { get; set; }
        public bool bloqueado { get; set; }
        public DateTime ultimoAcceso { get; set; }
    }

    public class UsuarioCrearVM
    {

    }

    public class UsuarioEditarVM
    {

    }


}
