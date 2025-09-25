using Npgsql;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly string _cadenaDeConexion;

        public UsuarioRepositorio(string cadenaDeConexion) => _cadenaDeConexion = cadenaDeConexion;

        public List<Usuario> obtenerUsuarios() 
        { 
            var usuarios = new List<Usuario>();
            NpgsqlConnection conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();

            string consultaString = @"SELECT id_usuario, apellidos, nombres, 
                                    cargo.id_cargo, cargo.cargo, cuil, direccion_correo, nombre_usuario, contrasena, bloqueado, 
                                    fecha_hora_ult_conectado, pin_temporal
	                                FROM usuario 
                                    INNER JOIN cargo USING(id_cargo)
                                    WHERE activo = true;";

            NpgsqlCommand comando = new NpgsqlCommand(consultaString, conexion);

            using (var reader = comando.ExecuteReader())
            {
                int idUsuario = 0;
                string apellidos = string.Empty;
                string nombres = string.Empty;
                string cuil = string.Empty;
                Cargo cargo = null;
                string direccionCorreo = string.Empty;
                string nombreUsuario = string.Empty;
                string contrasena = string.Empty;
                bool bloqueado;
                int pinTemporal;
                DateTime ultimoAcceso;

                while (reader.Read())
                {
                    idUsuario = Convert.ToInt32(reader["id_usuario"]);
                    apellidos = reader["apellidos"].ToString();
                    nombres = reader["nombres"].ToString();
                    cuil = reader["cuil"].ToString();
                    cargo = new Cargo(Convert.ToInt32(reader["id_cargo"]), reader["cargo"].ToString());
                    direccionCorreo = reader["direccion_correo"].ToString();
                    nombreUsuario = reader["nombre_usuario"].ToString();
                    contrasena = reader["contrasena"].ToString();
                    bloqueado = Convert.ToBoolean(reader["bloqueado"]);
                    pinTemporal = reader["pin_temporal"] == DBNull.Value ? 0 : Convert.ToInt32(reader["pin_temporal"]);
                    ultimoAcceso = Convert.ToDateTime(reader["fecha_hora_ult_conectado"]);

                    Usuario usuario = new Usuario(idUsuario, apellidos, nombres, cuil, cargo, direccionCorreo, nombreUsuario, contrasena, bloqueado, pinTemporal, ultimoAcceso);

                    usuarios.Add(usuario);
                }
            }
            conexion.Close();
            return usuarios;
        }
    }
}

