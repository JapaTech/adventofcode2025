using System;
using System.Text;
using System.Numerics;


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

        public static BigInteger DisjuntoresComMaiorEnergia2(string[] energiasDosDisjuntores, int qtdDisjuntores)
        {
            BigInteger energiaTotal = 0;
            

            foreach (var item in energiasDosDisjuntores)
            {
                int[] disjuntores = item.Select(c => int.Parse(c.ToString())).ToArray();
                SortedDictionary<int, int> maioresDisjuntores = new SortedDictionary<int, int>();

                int disjuntoreParaPegar = (disjuntores.Length - qtdDisjuntores);

                BigInteger contador = 0;
                List<int> indicesParaRemover = new List<int>();
                
                List<(int indice, int valor)> todosDigitos = new List<(int, int)>();
                for (int i = 0; i < disjuntores.Length; i++)
                {
                    todosDigitos.Add((i, disjuntores[i]));
                }

                while (indicesParaRemover.Count < disjuntoreParaPegar)
                {
                    var t = todosDigitos.Where(x => x.indice == contador);
                    BigInteger n = (BigInteger) t.First().valor;

                    n = n *  BigInteger.Pow(10, (todosDigitos.Count -2 - (int) contador));                    

                    var sb = new StringBuilder();
                    for (BigInteger i = contador + 1; i < todosDigitos.Count; i++)
                    {                        
                        sb.Append(todosDigitos[(int) i].valor.ToString());
                    }                    
                    BigInteger numerosRestantes = BigInteger.Parse(sb.ToString());


                    if (n < numerosRestantes)
                    {
                        indicesParaRemover.Add((int)contador);
                        todosDigitos.RemoveAll(x =>x.indice == contador);
                    }
                    if(contador <= 1 && indicesParaRemover.Count >= disjuntoreParaPegar)
                    {
                        contador = 0;
                    }
                    else
                    {
                        contador++;
                    }
 
                }

                for (int i = 0; i < disjuntores.Length; i++)
                {
                    if(indicesParaRemover.Contains(i))
                        continue;

                    maioresDisjuntores.Add(i, disjuntores[i]);
                }

                contador = 1;
                BigInteger maiorEnergia = 0;

                foreach (var disjuntor in maioresDisjuntores.Reverse())
                {
                    //Console.WriteLine($"Key {disjuntor.Key}, Value {disjuntor.Value}");
                    maiorEnergia += (BigInteger)disjuntor.Value * contador;
                    contador *= 10;
                }

                //Console.WriteLine("Maior energia: " + maiorEnergia);
                energiaTotal += maiorEnergia;
            }
            return energiaTotal;
        }
    }
}
