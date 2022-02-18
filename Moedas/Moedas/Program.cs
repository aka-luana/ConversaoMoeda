using System;
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
            //var resultRubloRusso = float.Parse(rubloRusso.high) * valorReais;

            var dolar = await _apiConveter.Api<Moeda>("RUB-USD");
            //var resultDolar = float.Parse(dolar.high) * resultRubloRusso;

            var resultReaisEmDolar = float.Parse(rubloRusso.BRLRUB.high) * float.Parse(dolar.RUBUSD.high) * valorReais;

            Console.WriteLine(resultReaisEmDolar);
            var testConfirmationResult = await _apiConveter.Api<Moeda>("BRL-USD");
            Console.WriteLine(float.Parse(testConfirmationResult.BRLUSD.high) * valorReais);
        }
    }
}
