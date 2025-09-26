namespace Data.Entities
{
    public class Cargo
    {
        public int IdCargo { get; set; }
        public string CargoName { get; set; }

        public Cargo()
        {
        }

        public Cargo(int idCargo, string cargoName)
        {
            IdCargo = idCargo;
            CargoName = cargoName;
        }
    }
}


