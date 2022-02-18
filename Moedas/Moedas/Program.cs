using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Moedas
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ApiConveter _apiConveter = new();

            Console.Write("Digite um valor em reais: R$");
            var valorReais = float.Parse(Console.ReadLine());
            while (valorReais < 0 || valorReais > 100)
            {
                Console.WriteLine("Valor inválido! Digite outro valor em reais: R$");
                valorReais = float.Parse(Console.ReadLine());
            }

            var rubloRusso = await _apiConveter.Api<Moeda>("BRL-RUB");

            var dolar = await _apiConveter.Api<Moeda>("RUB-USD");

            var resultReaisEmDolar = float.Parse(rubloRusso.BRLRUB.high.Replace(".", ",")) * float.Parse(dolar.RUBUSD.high.Replace(".", ",")) * valorReais;

            Console.WriteLine("Nossa conversao: R$" + resultReaisEmDolar.ToString("F2", CultureInfo.InvariantCulture));
            var testConfirmationResult = await _apiConveter.Api<Moeda>("BRL-USD");
            Console.WriteLine("Conversao de validacao: R$" + (float.Parse(testConfirmationResult.BRLUSD.high.Replace(".", ",")) * valorReais).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
