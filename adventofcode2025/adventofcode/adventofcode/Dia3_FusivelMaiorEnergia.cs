using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode
{
    public static class Dia3_FusivelMaiorEnergia
    {
        public static int DisjuntoresComMaiorEnergia1(string[] energiasDosDisjuntores)
        {
            int energiaTotal = 0;

            foreach (var item in energiasDosDisjuntores)
            {
                int[] disjuntores = item.Select(c => int.Parse(c.ToString())).ToArray();
                SortedDictionary<int, int> maioresDisjuntores = new SortedDictionary<int, int>();

                int valorMaior = disjuntores.Max();
                int maiorIndice = disjuntores.IndexOf(valorMaior);
                maioresDisjuntores.Add(maiorIndice, valorMaior);
                disjuntores[maiorIndice] = -1;

                if (maiorIndice == disjuntores.Length - 1)
                {
                    valorMaior = disjuntores.Max();
                    maiorIndice = disjuntores.IndexOf(valorMaior);
                    maioresDisjuntores.Add(maiorIndice, valorMaior);
                }
                else
                {
                    valorMaior = disjuntores.Skip(maiorIndice + 1).Max();
                    maiorIndice = Array.IndexOf(disjuntores, valorMaior, maiorIndice + 1);
                    maioresDisjuntores.Add(maiorIndice, valorMaior);
                }

                int maiorEnergia = 0;
                int contador = 1;

                foreach (var disjuntor in maioresDisjuntores.Reverse())
                {
                    Console.WriteLine($"Key {disjuntor.Key}, Value {disjuntor.Value}");
                    maiorEnergia += disjuntor.Value * contador;
                    contador *= 10;
                }


                Console.WriteLine("Maior energia: " + maiorEnergia);
                energiaTotal += maiorEnergia;
            }
            return energiaTotal;
        }

        public static ulong DisjuntoresComMaiorEnergia2(string[] energiasDosDisjuntores)
        {
            ulong energiaTotal = 0;

            foreach (var item in energiasDosDisjuntores)
            {
                int[] disjuntores = item.Select(c => int.Parse(c.ToString())).ToArray();
                SortedDictionary<int, int> maioresDisjuntores = new SortedDictionary<int, int>();

                int valorMaior = disjuntores.Max();
                int maiorIndice = disjuntores.IndexOf(valorMaior);
                maioresDisjuntores.Add(maiorIndice, valorMaior);
                disjuntores[maiorIndice] = -1;                

                for (int i = 0; i < 11; i++)
                {
                    
                    valorMaior = disjuntores.Max();

                    var maiorValorEsquerda = disjuntores.Select((valor, indice) => new { valor, indice })
                   .Take(maiorIndice).LastOrDefault(x => x.valor == valorMaior);
                    var maiorValorDireita = disjuntores.Select((valor, indice) => new { valor, indice })
                        .Skip(maiorIndice).FirstOrDefault(x => x.valor >= valorMaior);

                    ulong energiaEsquerda = 0;
                    ulong energiaDireita = 0;
                    ulong contador = 1;
                    var dijuntoresComEsquerda = new SortedDictionary<int, int>(maioresDisjuntores);
                    var dijuntoresComDireita = new SortedDictionary<int, int>(maioresDisjuntores);

                    if (maiorValorDireita != null)                 
                    {
                        dijuntoresComDireita.Add(maiorValorDireita.indice, maiorValorDireita.valor);
                        foreach (var disjuntor in dijuntoresComDireita.Reverse())
                        {
                            //Console.WriteLine($"Key {disjuntor.Key}, Value {disjuntor.Value}");
                            energiaDireita += (ulong)disjuntor.Value * contador;
                            contador *= 10;
                        }
                    }

                    contador = 1;
                    if (maiorValorEsquerda != null)                 
                    {
                        dijuntoresComEsquerda.Add(maiorValorEsquerda.indice, maiorValorEsquerda.valor);
                        foreach (var disjuntor in dijuntoresComEsquerda.Reverse())
                        {
                            //Console.WriteLine($"Key {disjuntor.Key}, Value {disjuntor.Value}");
                            energiaEsquerda += (ulong)disjuntor.Value * contador;
                            contador *= 10;
                        }

                    }

                    Console.WriteLine("Energia Esquerda---- " + energiaEsquerda);
                    Console.WriteLine("Energia Direita----- " + energiaDireita);
                    Console.WriteLine("===================");

                    if (energiaEsquerda > energiaDireita)
                    {
                        maioresDisjuntores.Add(maiorValorEsquerda.indice, maiorValorEsquerda.valor);                                              
                        maiorIndice = maiorValorEsquerda.indice;
                        disjuntores[maiorValorEsquerda.indice] = -1;
                    }
                    else
                    {
                        maioresDisjuntores.Add(maiorValorDireita.indice, maiorValorDireita.valor);
                        maiorIndice = maiorValorDireita.indice;
                        disjuntores[maiorValorDireita.indice] = -1;
                    }

                }

                ulong maiorEnergia = 0;
                ulong contadorFinal = 1;

                foreach (var disjuntor in maioresDisjuntores.Reverse())
                {
                    //Console.WriteLine($"Key {disjuntor.Key}, Value {disjuntor.Value}");
                    maiorEnergia += (ulong)disjuntor.Value * contadorFinal;
                    contadorFinal *= 10;
                }

                Console.WriteLine("Maior energia: " + maiorEnergia);
                energiaTotal += maiorEnergia;
            }
            return energiaTotal;
        }
    }
}
