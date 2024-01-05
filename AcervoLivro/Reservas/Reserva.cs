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

        public void ExibirInformacoes()
        {
            Console.WriteLine();
            Console.WriteLine($"Data da reserva: {DataReserva}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Cargo do usuário: {CargoUsuario}");
            Console.WriteLine();
        }
    }
}
