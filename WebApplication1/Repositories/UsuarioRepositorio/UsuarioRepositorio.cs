using Npgsql;
using System.Net;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Repositories
{
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly string _cadenaDeConexion;

        public UsuarioRepositorio(string cadenaDeConexion) => _cadenaDeConexion = cadenaDeConexion;



        public IEnumerable<Usuario> obtenerUsuarios() 
        { 
            var usuarios = new List<Usuario>();
            using var conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();
            const string consultaString = @"SELECT id_usuario, apellidos, nombres, cargo.id_cargo, cargo.cargo, 
                                    cuil, direccion_correo, nombre_usuario, bloqueado, 
                                    fecha_hora_ult_conectado
                                    FROM usuario 
                                    INNER JOIN cargo USING(id_cargo)
                                    WHERE activo = true
                                    ORDER BY apellidos, nombres;";
            using var comando = new NpgsqlCommand(consultaString, conexion);
            using var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                int idUsr = Convert.ToInt32(reader["id_usuario"]);
                string apellidos = reader["apellidos"].ToString();
                string nombres = reader["nombres"].ToString();
                Cargo cargo = new Cargo(Convert.ToInt32(reader["id_cargo"]), reader["cargo"].ToString());
                string cuil = reader["cuil"].ToString();
                string direccionCorreo = reader["direccion_correo"].ToString();
                string nombreUsuario = reader["nombre_usuario"].ToString();
                bool bloqueado = Convert.ToBoolean(reader["bloqueado"]);
                DateTime ultimoAcceso = Convert.ToDateTime(reader["fecha_hora_ult_conectado"]);

                var usuario = new Usuario
                {
                    IdUsuario = idUsr,
                    Apellidos = apellidos,
                    Nombres = nombres,
                    Cargo = cargo,
                    Cuil = cuil,
                    DireccionCorreo = direccionCorreo,
                    NombreUsuario = nombreUsuario,
                    Bloqueado = bloqueado,
                    FechaHoraUltConectado = ultimoAcceso
                };

                usuarios.Add(usuario);
            }
            return usuarios;
        }



        /*
        public Usuario obtenerUsuarioPorId(int idUsuario)
        {
            Usuario usuario = null;
            using var conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();
            const string consultaString = @"SELECT id_usuario, apellidos, nombres, cargo.id_cargo, cargo.cargo, 
                                    cuil, direccion_correo, nombre_usuario, contrasena, bloqueado, 
                                    fecha_hora_ult_conectado, pin_temporal
                                    FROM usuario 
                                    INNER JOIN cargo USING(id_cargo)
                                    WHERE activo = true AND id_usuario = @idUsuario;";

            using var comando = new NpgsqlCommand(consultaString, conexion);
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            using var reader = comando.ExecuteReader();
            
          
                if (reader.Read())
                {
                    int idUsr = Convert.ToInt32(reader["id_usuario"]);
                    string apellidos = reader["apellidos"].ToString();
                    string nombres = reader["nombres"].ToString();
                    string cuil = reader["cuil"].ToString();
                    Cargo cargo = new Cargo(Convert.ToInt32(reader["id_cargo"]), reader["cargo"].ToString());
                    string direccionCorreo = reader["direccion_correo"].ToString();
                    string nombreUsuario = reader["nombre_usuario"].ToString();
                    string contrasena = reader["contrasena"].ToString();
                    bool bloqueado = Convert.ToBoolean(reader["bloqueado"]);
                    int pinTemporal = reader["pin_temporal"] == DBNull.Value ? 0 : Convert.ToInt32(reader["pin_temporal"]);
                    DateTime ultimoAcceso = Convert.ToDateTime(reader["fecha_hora_ult_conectado"]);

                    usuario = new Usuario(idUsr, apellidos, nombres, cuil, cargo, direccionCorreo, nombreUsuario, contrasena, bloqueado, pinTemporal, ultimoAcceso);
                }
        
            return usuario;
        }

        public void editarUsuario(Usuario usuario)
        {
            using var conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();
            const string consultaString = @"UPDATE usuario 
                                       SET apellidos = @apellidos, 
                                           nombres = @nombres, 
                                           cuil = @cuil,
                                           direccion_correo = @direccionCorreo, 
                                           nombre_usuario = @nombreUsuario,  
                                           bloqueado = @bloqueado, 
                                           pin_temporal = @pinTemporal 
                                       WHERE id_usuario = @idUsuario;";

            using var comando = new NpgsqlCommand(consultaString, conexion);

            comando.Parameters.AddWithValue("@apellidos", usuario.apellidos);
            comando.Parameters.AddWithValue("@nombres", usuario.nombres);
            comando.Parameters.AddWithValue("@cuil", usuario.cuil);
            comando.Parameters.AddWithValue("@direccionCorreo", usuario.direccionCorreo);
            comando.Parameters.AddWithValue("@nombreUsuario", usuario.nombreUsuario);
            comando.Parameters.AddWithValue("@bloqueado", usuario.bloqueado);
            if (usuario.pinTemporal.HasValue)
                comando.Parameters.AddWithValue("@pinTemporal", usuario.pinTemporal.Value);
            else
                comando.Parameters.AddWithValue("@pinTemporal", DBNull.Value);
            comando.Parameters.AddWithValue("@idUsuario", usuario.idUsuario);
            comando.ExecuteNonQuery();

        }
        */
    }
}

