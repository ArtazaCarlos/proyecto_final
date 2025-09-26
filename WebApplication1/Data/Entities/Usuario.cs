namespace Data.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public string Dni { get; set; }
        public int? IdCargo { get; set; }
        public string Cuil { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string DireccionCorreo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime FechaHoraUltConectado { get; set; }
        public short? PinTemporal { get; set; }
        public bool Activo { get; set; }
 
    }

}


