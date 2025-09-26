using WebApplication1.ViewModels;

namespace WebApplication1.ViewModels
{
    public class MostrarUsuariosVM
    {
        public List<UsuarioListarVM> usuarios { get; }

        public MostrarUsuariosVM(List<UsuarioListarVM> usuarios)
        {
            this.usuarios = usuarios;
        }
    }
}
