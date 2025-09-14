using Npgsql;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Repositorios
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly string _cadenaDeConexion;

        public UsuarioRepositorio(string cadenaDeConexion) => _cadenaDeConexion = cadenaDeConexion;

        public List<Usuario> ObtenerUsuarios() 
        { 
            var usuarios = new List<Usuario>();
            NpgsqlConnection conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();

            string consultaString = @"SELECT id_usuario, apellidos, nombres, sexo, 
                                    dni, cargo.cargo, cuil, domicilio, telefono, 
                                    direccion_correo, nombre_usuario, contrasena, bloqueado, 
                                    fecha_hora_ult_conectado, pin_temporal
	                                FROM usuario 
                                    INNER JOIN cargo USING(id_cargo)
                                    WHERE activo = true;";

            NpgsqlCommand comando = new NpgsqlCommand(consultaString, conexion);

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = Convert.ToInt32(reader["id_usuario"]),
                        Apellidos = reader["apellidos"].ToString(),
                        Nombres = reader["nombres"].ToString(),
                        Sexo = reader["sexo"].ToString(),
                        Dni = reader["dni"].ToString(),
                        Cuil = reader["cuil"].ToString(),
                        Cargo = reader["cargo"].ToString(),
                        Domicilio = reader["domicilio"].ToString(),
                        Telefono = reader["telefono"].ToString(),
                        DireccionCorreo = reader["direccion_correo"].ToString(),
                        NombreDeUsuario = reader["nombre_usuario"].ToString(),
                        Contrasena = reader["contrasena"].ToString(),
                        Bloqueado = Convert.ToBoolean(reader["bloqueado"]),
                        PINTemporal = reader["pin_temporal"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["pin_temporal"]),
                        UltimoAcceso = Convert.ToDateTime(reader["fecha_hora_ult_conectado"])
                    };

                    usuarios.Add(usuario);
                }
            }
            conexion.Close();
            return usuarios;
        }

        public void CrearUsuario(Usuario nuevoUsuario) { }
        public void ActualizarUsuario(Usuario usuarioRegistrado) { }
        public void EliminarUsuario(string cuil) { }
    }
}

