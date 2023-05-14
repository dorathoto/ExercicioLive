using ExercicioLive.Models;
using ExercicioLive.Models.Enums;
using System.Linq;


namespace ExercicioLive
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var lista = new List<Cadastro>();
            var rnd = new Random();

            for (int i = 1; i < 40000; i++)
            {
                var num = rnd.Next(0, 10);
                var num2 = rnd.Next(0, 555);

                var cad = new Cadastro
                {
                    CadastroId = i,
                    Funcao = (TipoFuncao)num,
                    Nome = $"Nome {i}",
                    Salario = 1000m * num2,
                    

                };
                lista.Add(cad);
               // Console.WriteLine($"[{i}] - Nome: {cad.Nome} - Sal: {cad.Salario} - Função: {cad.Funcao}");

                

            }
            Console.BackgroundColor = ConsoleColor.DarkBlue; 
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();

            Console.WriteLine("#####################################");
            Console.WriteLine("##########   STATS     ##############");
            Console.WriteLine($"Total de registros: {lista.Count}");
            Console.WriteLine($"Total de registros com salário maior que 3000: {lista.Where(w => w.Salario > 3000).Count()}");
            Console.WriteLine($"Total de registros com salário menor que 3000: {lista.Where(w => w.Salario < 3000).Count()}");
            Console.WriteLine($"Total de registros com salário igual a 3000: {lista.Where(w => w.Salario == 3000).Count()}");
            Console.WriteLine($"Total de registros com salário igual a 0:{lista.Where(p => p.Salario == 0).Count()} ");


            //Console.WriteLine($"Total funcao igual a 1-RH {lista.Where(w => w.Funcao == TipoFuncao.RH).Count()}");
            //Console.WriteLine($"Total funcao igual a 2-cLEvel {lista.Where(w => w.Funcao == TipoFuncao.CLeve).Count()}");
            //Console.WriteLine($"Total funcao igual a 3 {lista.Where(w => w.Funcao == TipoFuncao.Financeiro).Count()}");
            Console.WriteLine("-------------------------------------");
            //avançado
            foreach (var item in Enum.GetValues(typeof(TipoFuncao)))
            {
                var funcao = (TipoFuncao)item;

                Console.WriteLine($"Qtd. reg. com func. {item}: {lista.Where(w => w.Funcao == funcao).Average(s=> s.Salario)} ");
            }

            Console.WriteLine("-------------------------------------");

            var FuncsMaiorSalario = lista.OrderByDescending(s => s.Salario).Take(100).ToList();
            foreach (var item in FuncsMaiorSalario)
            {
                Console.WriteLine($"Nome: {item.Nome} - Func.{item.Funcao} - Sal. {item.Salario}");
            }
            
    



            Console.WriteLine("-------------------------------------");


            var lista2 = new List<Cadastro>();
            bool continuarLoop = true;
            do
            {
                var cadastro = new Cadastro();
                Console.WriteLine("Digite o nome do funcionário:");
                cadastro.Nome = Console.ReadLine();

                Console.WriteLine("Digite o Salario do func:");
                cadastro.Salario = Convert.ToDecimal(Console.ReadLine());


                Console.WriteLine("Digite a funcao (0 a 10):");
                var recebeValor = Console.ReadLine();
                var intValor = Convert.ToInt32(recebeValor);
                var funcao = (TipoFuncao)intValor;

                cadastro.Funcao = funcao; // (TipoFuncao)Convert.ToInt32(Console.ReadLine());



                Console.WriteLine("Deseja continuar? (S/N)");
                var resposta = Console.ReadLine();
                if(resposta?.ToLower() == "N")
                {
                    continuarLoop = false;
                }



            } while (continuarLoop);


            Console.ReadLine();

        }
    }
}