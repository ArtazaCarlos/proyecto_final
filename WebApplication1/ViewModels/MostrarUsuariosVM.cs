using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class MostrarUsuariosVM
    {
        public List<Usuario> usuarios { get; }

        public MostrarUsuariosVM(List<Usuario> usuarios)
        {
            this.usuarios = usuarios;
        }
    }
}
