namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if(Suite is null) { CriarExcecao("Não há Suites Cadastradas"); }
            
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                CriarExcecao("Número de Hóspedes maior que a capacidade da Suite");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            if(Hospedes is null) { CriarExcecao("Não há Hóspedes Cadastrados"); }

            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if(Suite is null) { CriarExcecao("Não há Suites Cadastradas"); }

            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados > 9)
            {
                valor = valor - valor*10/100;
            }

            return valor;
        }

        private void CriarExcecao(string mensagem)
        {
            throw new Exception(mensagem);
        }
    }
}