using ExercicioLive.Models.Enums;

namespace ExercicioLive.Models
{
    public class Cadastro
    {
        public int CadastroId { get; set; }

        //refatorar depois para enum
        public TipoFuncao Funcao { get; set; }

        public string Nome { get; set; }

        public decimal Salario {  get;  set; }
        

        public decimal SalarioEmDolar { get { return Salario * 5; } }
    }
}
