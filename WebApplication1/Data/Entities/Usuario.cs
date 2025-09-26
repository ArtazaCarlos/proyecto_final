namespace Data.Entities
{
    public class UsuarioEntity
    {
        public int IdUsuario { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public int? IdCargo { get; set; }
        public string Cuil { get; set; }
        public string DireccionCorreo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime FechaHoraUltConectado { get; set; }
        public short? PinTemporal { get; set; }
        public bool Activo { get; set; }
 
    }

}


