using Data.Entities;
using Npgsql;
using System.Net;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using System.Security.Cryptography;
using System.Text;

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
                                    LEFT JOIN cargo USING(id_cargo)
                                    WHERE activo = true
                                    ORDER BY apellidos, nombres;";
            using var comando = new NpgsqlCommand(consultaString, conexion);
            using var reader = comando.ExecuteReader();
            while (reader.Read())
            {
                int idUsr = Convert.ToInt32(reader["id_usuario"]);
                string apellidos = reader["apellidos"].ToString();
                string nombres = reader["nombres"].ToString();

                Cargo cargo = null;
                if (reader["id_cargo"] != DBNull.Value)
                {
                    cargo = new Cargo(
                        Convert.ToInt32(reader["id_cargo"]),
                        reader["cargo"].ToString()
                    );
                }

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

        
        public Usuario obtenerUsuarioPorId(int idUsuario)
        {
            Usuario usuario = null;
            using var conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();
            const string consultaString = @"SELECT id_usuario, apellidos, nombres, 
                                    cuil, direccion_correo, nombre_usuario, bloqueado, 
                                    fecha_hora_ult_conectado
                                    FROM usuario 
                                    WHERE activo = true AND id_usuario = @idUsuario;";
            using var comando = new NpgsqlCommand(consultaString, conexion);
            comando.Parameters.AddWithValue("@idUsuario", idUsuario);
            using var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                int idUsr = Convert.ToInt32(reader["id_usuario"]);
                string apellidos = reader["apellidos"].ToString();
                string nombres = reader["nombres"].ToString();
                //Cargo cargo = new Cargo(Convert.ToInt32(reader["id_cargo"]), reader["cargo"].ToString());
                string cuil = reader["cuil"].ToString();
                string direccionCorreo = reader["direccion_correo"].ToString();
                string nombreUsuario = reader["nombre_usuario"].ToString();
                bool bloqueado = Convert.ToBoolean(reader["bloqueado"]);
                DateTime ultimoAcceso = Convert.ToDateTime(reader["fecha_hora_ult_conectado"]);
                usuario = new Usuario
                {
                    IdUsuario = idUsr,
                    Apellidos = apellidos,
                    Nombres = nombres,
                    //Cargo = cargo,
                    Cuil = cuil,
                    DireccionCorreo = direccionCorreo,
                    NombreUsuario = nombreUsuario,
                    Bloqueado = bloqueado,
                    FechaHoraUltConectado = ultimoAcceso
                };
            }
            return usuario;
        }



        public void editarUsuario(UsuarioEntity usuario)
        {
            using var conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();
            const string consultaString = @"UPDATE usuario 
                                       SET apellidos = @apellidos, 
                                           nombres = @nombres, 
                                           cuil = @cuil,
                                           direccion_correo = @direccionCorreo, 
                                           bloqueado = @bloqueado 
                                       WHERE id_usuario = @idUsuario;";

            using var comando = new NpgsqlCommand(consultaString, conexion);
            comando.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
            comando.Parameters.AddWithValue("@nombres", usuario.Nombres);
            comando.Parameters.AddWithValue("@cuil", usuario.Cuil);
            comando.Parameters.AddWithValue("@direccionCorreo", usuario.DireccionCorreo);
            comando.Parameters.AddWithValue("@bloqueado", usuario.Bloqueado);
            comando.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);
            comando.ExecuteNonQuery();
        }

        public void crearUsuario(UsuarioEntity usuarioEntity)
        {
            using var conexion = new NpgsqlConnection(_cadenaDeConexion);
            conexion.Open();
            const string consultaString = @"INSERT INTO usuario 
                                       (apellidos, nombres, cuil, direccion_correo, nombre_usuario, contrasena, bloqueado, fecha_hora_ult_conectado, activo) 
                                       VALUES 
                                       (@apellidos, @nombres, @cuil, @direccionCorreo, @apellidos || (SELECT MAX(id_usuario) FROM usuario), @contrasena, false, @fechaHoraUltConectado, true);";
            using var comando = new NpgsqlCommand(consultaString, conexion);
            comando.Parameters.AddWithValue("@apellidos", usuarioEntity.Apellidos);
            comando.Parameters.AddWithValue("@nombres", usuarioEntity.Nombres);
            //comando.Parameters.AddWithValue("@idCargo", usuarioEntity.IdCargo.HasValue ? (object)usuarioEntity.IdCargo.Value : DBNull.Value);
            comando.Parameters.AddWithValue("@cuil", usuarioEntity.Cuil);
            comando.Parameters.AddWithValue("@direccionCorreo", usuarioEntity.DireccionCorreo);
            comando.Parameters.AddWithValue("@contrasena", HashPassword(usuarioEntity.Contrasena));
            comando.Parameters.AddWithValue("@fechaHoraUltConectado", DateTime.Now);
            comando.ExecuteNonQuery();
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}


