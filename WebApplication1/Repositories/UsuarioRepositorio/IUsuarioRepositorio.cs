using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IUsuarioRepositorio
    {
        List<Usuario> obtenerUsuarios();
        Usuario obtenerUsuarioPorId(int idUsuario);

    }
}
