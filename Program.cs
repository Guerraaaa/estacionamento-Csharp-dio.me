// See https://aka.ms/new-console-template for more information

// To-Do
// deverá ser feito um menu interativo

Estacionamento estacionamento = new Estacionamento();

estacionamento.LimparConsole();
Console.Write("===== Sistema ===== \n");

bool inicio = true;

while (inicio)
{
    Console.Write("Informe o valor de entrada do estacionamento: ");
    string precoInicial = Console.ReadLine() ?? "ERRO";
    precoInicial = precoInicial.Replace('.', ',');
    if (!string.IsNullOrEmpty(precoInicial) && precoInicial != "ERRO")
    {
        bool sucesso = Double.TryParse(precoInicial, out double precoInicialDouble);
        if (sucesso)
            estacionamento.SetPriceInit(precoInicialDouble);
        else
        {
            Console.WriteLine("Valor Invalido, por favor tente novamente!");
            estacionamento.LimparConsole();
        }
    }
    else
    {
        Console.WriteLine("Valor Invalido, por favor tente novamente!");
        estacionamento.LimparConsole();
    }

    Console.Write("Informe o valor da hora cobrada do estacionamento: ");
    string precoPerHour = Console.ReadLine() ?? "ERRO";
    precoPerHour = precoPerHour.Replace('.', ',');
    if (!string.IsNullOrEmpty(precoPerHour) && precoPerHour != "ERRO")
    {
        bool sucesso = Double.TryParse(precoPerHour, out double precoPerHourDouble);
        if (sucesso)
        {
            estacionamento.SetPricePerHour(precoPerHourDouble);
            inicio = false;
        }
        else
        {
            estacionamento.LimparConsole("Valor Invalido, por favor tente novamente!");
        }
    }
    else
    {
        estacionamento.LimparConsole("Valor Invalido, por favor tente novamente!");
    }
}

estacionamento.LimparConsole();
bool continuar = true;
while (continuar)
{
    Console.Write("===== Seja bem vindo! ===== \n");
    Console.Write("1 - Adicionar placa \n");
    Console.Write("2 - Remover placa \n");
    Console.Write("3 - Listar carros \n");
    Console.Write("4 - Encerrar \n");
    Console.Write("Escolha umas opcoes acima: ");

    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            estacionamento.AdicionarPlaca();
            break;
        case "2":
            estacionamento.RemoverVeiculo();
            break;
        case "3":
            estacionamento.ListarCarros();
            break;
        case "4":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opcao Invalida");
            estacionamento.LimparConsole();
            break;
        
    }
}