using Data.Entities;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> obtenerUsuarios();
        Usuario obtenerUsuarioPorId(int idUsuario);
        void editarUsuario(UsuarioEntity usuario);
        void crearUsuario(UsuarioEntity usuario);
        void eliminarUsuario(int idUsuario);
    }
}
