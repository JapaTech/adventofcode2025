using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode
{
    public static class Dia3_FusivelMaiorEnergia
    {
        public static int DisjuntoresComMaiorEnergia(string[] energiasDosDisjuntores)
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

                if (maiorIndice == disjuntores.Length -1)
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
    }
}
