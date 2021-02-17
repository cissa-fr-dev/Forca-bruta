using System;
using System.Collections.Generic;
/// <summary>
/// 
///     A solução exaustiva para este problema consiste em considerar "TODOS" os subconjuntos
///         do conjunto de "n" itens dados, calculando o peso total de cada subconjunto para 
///         identificar subconjuntos aplicáveis e encontrar um subconjunto com o valor mais 
///         elevado entre eles.
///         
///     Como o número de subconjuntos de um conjunto "n" de elementos é 2^n, a busca exaustiva
///         leva a um algoritmo O(2^n).
///         
/// </summary>
namespace ForcaBruta
{
    class Item
    {
        public int Peso { get; set; }
        public int Valor { get; set; }

        public Item(int peso, int valor)
        {
            Peso = peso;
            Valor = valor;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> itens = new List<Item>();
            itens.Add(new Item(12, 4));
            itens.Add(new Item(2, 2));
            itens.Add(new Item(1, 1));
            itens.Add(new Item(4, 10));
            itens.Add(new Item(1, 2));
            int mochila = 15;

            ForcaBruta(itens, mochila);

            Console.ReadKey();
        }

        static void ForcaBruta(List<Item> itens, int mochila)
        {
            int totalItens = itens.Count;
            int combinacoes = (int)Math.Pow(2, totalItens);

            string combinacaoResultado = "";
            int melhorValor = 0;
            int pesoOcupado = 0;

            Console.WriteLine("\n\t Combinações possíveis:\t");
            Console.WriteLine("\t-------------------------");
            for (int i = 0; i < combinacoes; i++)
            {
                string binario = Convert.ToString(i, 2);
                binario = binario.PadLeft(totalItens, '0'); // O que não tiver 0, ele preenche à esquerda com 0.

                int valorTotal = 0;
                int pesoTotal = 0;

                for (int j = 0; j < totalItens; j++)
                {
                    if (binario[j] != '0')
                    {
                        pesoTotal += itens[j].Peso;
                        valorTotal += itens[j].Valor;
                    }
                }
                Console.WriteLine($"\t{binario} - Peso: {pesoTotal} Valor: {valorTotal}");

                if (pesoTotal <= mochila && valorTotal > melhorValor)
                {
                    combinacaoResultado = binario;
                    melhorValor = valorTotal;
                    pesoOcupado = pesoTotal;
                }
            }

            Console.WriteLine($"\n\n\tResposta: {combinacaoResultado} - Peso: {pesoOcupado} Valor: {melhorValor}");
        }
    }
}