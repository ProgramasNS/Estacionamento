//Imports
using Estacionamento.classes;
using System.Collections.Generic;
using System.Linq.Expressions;
//Variáveis
decimal preço, porHora;
List<Carro> carros = new List<Carro>();
string escolha = "";
//Funções
void MostraLinha(string linha) //Esta função serve para decorar títulos, servindo como substituto para logotipos 
{
    Console.WriteLine("====================");
    Console.WriteLine(linha.ToUpper());
    Console.WriteLine("=====================");
}

void Programa() //Esse é o programa sendo executado.
{
    string placa = "";
    Console.WriteLine("Digite a sua opção:\n[1]Cadastrar veículo\n[2]Remover veículo\n[3]Listar veículos\n[4]Encerrar");
    Console.Write("Insira sua escolha aqui: ");
    escolha = Console.ReadLine();
    if (escolha.Equals("1"))
    {
        Console.WriteLine("Digite a placa do veículo para estacionar: ");
        placa = Console.ReadLine();
        carros.Add(new Carro(placa));
    }
    else if (escolha.Equals("2"))
    {
        Console.Write("Digite a placa do veículo que deseja remover: ");
        placa = Console.ReadLine();
        Carro removido = carros.FirstOrDefault(carro => carro.placa == placa);
        removido.preço = preço;
        if (removido != null)
        {
            Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
            removido.horas = Convert.ToInt32(Console.ReadLine());
            carros.Remove(removido);
            Console.WriteLine($"O veículo {removido.placa} foi removido e o preço total foi de {removido.horas * removido.preço}");
        }
        else
        {
            Console.WriteLine("Veículo não encontrado!");
        }
        
    }
    else if (escolha.Equals("3"))
    {
        if (carros.Count > 0)
        {
            foreach (Carro i in carros)
            {
                MostraLinha($"Carro {carros.IndexOf(i) + 1}");
                Console.WriteLine($"Placa: {i.placa}");
                Console.WriteLine($"Preço inicial: {i.preço}");
            }
        }
        else
        {
            Console.WriteLine("Nenhum carro foi cadastrado!");
        }
    }
}

//Programa principal
MostraLinha("Bem-vindo(a) ao sistema de estacionamento!");
Console.Write("Digite o preço inicial: ");
try
{
    preço = Decimal.Parse(Console.ReadLine());
}
catch (FormatException) //Caso o usuário, ao invés de digitar algo que não é um número ou simplesmente apertar "Enter"
{
    preço = 0;
}
Console.Write("Digite o valor cobrado por hora: R$ ");
try
{
    porHora = Decimal.Parse(Console.ReadLine());
}
catch (FormatException)
{
    porHora = 0;
}
finally
{
    while (!escolha.Equals("4"))
    {
        Programa();
    }
}