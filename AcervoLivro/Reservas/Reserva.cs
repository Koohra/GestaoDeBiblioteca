namespace ControleDoAcervo.Reservas
{
    public class Reserva
    {
        public DateTime? DataReserva { get; set; }
        public string Matricula { get; set; }
        public CargoUsuario CargoUsuario { get; set; }

        public Reserva(string Matricula, DateTime? DataReserva = default)
        {
            this.Matricula = Matricula;

            if (DataReserva == default)
                DataReserva = DateTime.Now;
            else
                this.DataReserva = DataReserva;

            if (Matricula.Any(digito => digito == 'p'))
                CargoUsuario = CargoUsuario.Professor;
            else
                CargoUsuario = CargoUsuario.Estudante;
        }
    }
}
