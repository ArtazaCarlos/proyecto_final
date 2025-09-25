namespace WebApplication1.Models
{
    public class Cargo
    {
        private int idCargo;
        private string cargo;
        public int IdCargo { get => idCargo; }
        public string NombreCargo { get => cargo; }
        public Cargo(int idCargo, string cargo)
        {
            this.idCargo = idCargo;
            this.cargo = cargo;
        }
        public Cargo() { }
    }
}
