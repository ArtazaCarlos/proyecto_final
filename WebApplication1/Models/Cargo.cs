namespace WebApplication1.Models
{
    public class Cargo
    {
        private int idCargo;
        private string cargo;

        
        public int IdCargo { get => idCargo; set { idCargo = IdCargo; } }
        public string NombreCargo { get => cargo; set { cargo = NombreCargo; } }

        

        public Cargo(int idCargo, string cargo)
        {
            this.idCargo = idCargo;
            this.cargo = cargo;
        }
        public Cargo() { }
    }
}
