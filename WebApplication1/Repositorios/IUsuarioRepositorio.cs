using WebApplication1.Models;

namespace WebApplication1.Repositorios
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> ObtenerUsuarios();
        void CrearUsuario(Usuario nuevoUsuario);
        void ActualizarUsuario(Usuario usuarioRegistrado);
        void EliminarUsuario(string cuil);
    }
}
