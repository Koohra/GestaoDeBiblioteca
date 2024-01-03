namespace ControleDoAcervo.Reservas
{
    public class Reserva
    {
        public DateTime? DataReserva { get; set; }
        public string Matricula { get; set; }
        public CargoUsuario CargoUsuario { get; set; }

        public Reserva(string Matricula, CargoUsuario CargoUsuario, DateTime? DataReserva = default)
        {
            this.Matricula = Matricula;
            this.CargoUsuario = CargoUsuario;

            if (DataReserva == default)
                DataReserva = DateTime.Now;
            else
                this.DataReserva = DataReserva;
        }
    }
}
