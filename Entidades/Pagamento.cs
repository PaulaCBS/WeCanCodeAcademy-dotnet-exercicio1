using System;

namespace WCCA_Exercício1.Entidades
{
     class Pagamento
    {
        public Guid CodigoBarra { get; set; }
        public double Valor { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Confirmacao { get; set; }
        public string Cpf { get; set; }
        public string Descricao { get; set; }

        public bool EstaPago()
        {
            return Confirmacao;
        }
        public bool EstaVencido()
        {
            return DataVencimento < DateTime.Now;
        }
        public void Pagar()
        {
            DataPagamento = DateTime.Now;
            Confirmacao = true;
        }
    }

    class Boleto : Pagamento
    {
        private const int DiasVencimento = 15;
        private const double Juros = 0.10;
        public Boleto(string cpf,
                        double valor,
                        string descricao)
        {
            Cpf = cpf;
            Valor = valor;
            Descricao = descricao;

            DataEmissao = DateTime.Now;
            Confirmacao = false;
        }

        public void GerarBoleto()
        {
            CodigoBarra = Guid.NewGuid();
            DataVencimento = DataEmissao.AddDays(DiasVencimento);
        }

        public void CalcularJuros()
        {
            var taxa = Valor * Juros;
            Valor += taxa;
        }

    }

    class Dinheiro : Pagamento
    {
        public Dinheiro(string cpf,
                        double valor,
                        string descricao)
        {
            Cpf = cpf;
            Valor = valor;
            Descricao = descricao;
            Confirmacao = false;
        }

        public void GerarCodigo()
        {
            CodigoBarra = Guid.NewGuid();
        }
    }
}
