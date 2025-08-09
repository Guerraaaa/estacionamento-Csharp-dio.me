/* 
----- Desafio ----- 

Você foi contratado para construir um sistema para um estacionamento, 
que será usado para gerenciar os veículos estacionados e realizar suas operações, 
como por exemplo adicionar um veículo, remover um veículo 
(e exibir o valor cobrado durante o período) e listar os veículos.

*/

class Estacionamento
{
    double priceInit { get; set; }
    double pricePerHour { get; set; }

    List<string> cars { get; set; }

    public Estacionamento()
    {
        this.priceInit = 0;
        this.pricePerHour = 0;
        this.cars = [];
    }

    public void LimparConsole()
    {
        Thread.Sleep(2000);
        Console.Clear();
    }
    public void LimparConsole(string text)
    {
        Console.Write(text);
        Thread.Sleep(5000);
        Console.Clear();
    }
    public void LimparConsole(int time)
    {
        Thread.Sleep(time);
        Console.Clear();
    }

    public void RemoverVeiculo()
    {
        Console.WriteLine("Informe a placa do carro: ");
        string placa = Console.ReadLine() ?? "erro";

        Console.WriteLine("\n Informe a quantidade de horas que o carro ficou estacionado: ");
        string hourString = Console.ReadLine() ?? "erro";
        bool res = int.TryParse(hourString, out int hour);

        if (placa != "erro" && res)
            foreach (string placasCadastradas in cars)
            {
                if (placasCadastradas == placa)
                {
                    cars.Remove(placa);
                    double totalHora = pricePerHour * hour;
                    double total = priceInit + totalHora;

                    Console.WriteLine($"\n O carro com a placa {placa} foi processado com sucesso!");
                    Console.WriteLine($"Valor Total: {total:C}");

                    LimparConsole(5000);
                    break;
                }
            }
        else
        {
            LimparConsole("Placa Invalida");
        }
    }

    public void AdicionarPlaca()
    {
        Console.WriteLine("Informe a placa do carro: ");
        string placa = Console.ReadLine() ?? "erro";

        if (!string.IsNullOrEmpty(placa) && placa != "erro")
        {
            bool isDuplicado = false;
            foreach (string item in cars)
            {
                if (item == placa)
                    isDuplicado = true;
            }
            if (!isDuplicado)
            {
                cars.Add(placa);
                LimparConsole("\n === ✔ Cadastrado com Sucesso! === \n");
            }
            else
            {
                LimparConsole("Placa duplicada!");
            }
                
        }
    }

    public void ListarCarros()
    {
        Console.WriteLine("\n === 🚗 Carros cadastrados: ");
        foreach (string car in cars)
        {
            Console.WriteLine(car);
        }
        LimparConsole();
    }

    public void SetPriceInit(double price)
    {
        this.priceInit = price;
    }
    public void SetPricePerHour(double price)
    {
        this.pricePerHour = price;
    }
}