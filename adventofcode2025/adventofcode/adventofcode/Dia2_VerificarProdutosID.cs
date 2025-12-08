using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode;

public static class Dia2_VerificarProdutosID
{
    public static ulong ProdutosComIDIncorreto1(string id)
    {
        ulong acumulador = 0;

        string[] intervalos = id.Split(',');

        foreach (var intervalo in intervalos)
        {
            string[] limites = intervalo.Split('-');
            ulong limiteMin = ulong.Parse(limites[0]);
            ulong limiteMax = ulong.Parse(limites[1]);

            for (ulong i = limiteMin; i <= limiteMax; i++)
            {
                string idAtual = i.ToString();
                string primeiraMetadeDoID = idAtual.Substring(0, idAtual.Length / 2);
                string segundaMetadeDoID = idAtual.Substring(idAtual.Length / 2);

                if (primeiraMetadeDoID == segundaMetadeDoID)
                {
                    Console.WriteLine("ID inválido: " + idAtual);
                    acumulador += ulong.Parse(idAtual);
                }
            }
        }
        return acumulador;
    }

    public static ulong ProdutosComIDIncorreto2(string ids)
    {
        ulong acumulador = 0;

        string[] intervalos = ids.Split(',');

        foreach (var intervalo in intervalos)
        {
            string[] limites = intervalo.Split('-');
            ulong limiteMin = ulong.Parse(limites[0]);
            ulong limiteMax = ulong.Parse(limites[1]);

            for (ulong id = limiteMin; id <= limiteMax; id++)
            {
                string idAtual = id.ToString();
                bool numeroInvalido = false;
                for (ulong i = 1; i <= (ulong)(idAtual.Length / 2); i++)
                {
                    string conjuntoChar = idAtual.Substring(0, (int)i);          

                    bool verificouStringInteira = false;
                    for (ulong k = 0; k <= (ulong)idAtual.Length; k++)
                    {

                        if(verificouStringInteira && numeroInvalido)
                        {
                            break;
                        }

                        ulong proximoInicio = (ulong)conjuntoChar.Length * k;
                        ulong proximoFim = proximoInicio + (ulong)conjuntoChar.Length;

                        if (proximoFim > (ulong)idAtual.Length)
                        {
                            break;
                        }

                        string nextSubstring = idAtual.Substring((int)proximoInicio, conjuntoChar.Length);
                        //Console.WriteLine("String atual: " + nextSubstring);
                        //Console.WriteLine("Conjunto char: " + conjuntoChar);
                        //Console.WriteLine("Verificação da vez: " + i);
                        //Console.WriteLine("----------------------");
                        if (idAtual.Length % 2 == 0)
                        {
                            if (idAtual.Length / 2 == conjuntoChar.Length)
                            {
   
                                if (idAtual.Substring(0, idAtual.Length / 2) == idAtual.Substring(idAtual.Length /2))
                                {
                                    numeroInvalido = true;
                                }
                                else
                                {
                                    numeroInvalido = false;
                                }
                                verificouStringInteira = true;
                                break;
                            }
                            else if (nextSubstring == conjuntoChar)
                            {
                                if(proximoFim == (ulong)idAtual.Length)
                                {
                                    verificouStringInteira = true;
                                }
                                numeroInvalido = true;                               
                                continue;
                            }
                            else
                            {
                                numeroInvalido = false;
                                break;
                            }
                        }
                        else
                        {
                            if (nextSubstring == conjuntoChar)
                            {
                                numeroInvalido = true;
                                if(idAtual.Length - (int) proximoFim == 1)
                                {
                                    if(idAtual.Substring((int) proximoFim) == conjuntoChar)
                                    {
                                        numeroInvalido = true;
                                    }
                                    else 
                                    {
                                        numeroInvalido = false;
                                    }
                                        verificouStringInteira = true;
                                }
                                if(idAtual.Length == (int) proximoFim)
                                {
                                    verificouStringInteira = true;
                                    break;
                                }

                                continue;
                            }
                            else
                            {
                                numeroInvalido = false;
                                break;
                            }
                            
                        }

                    }
                    if (numeroInvalido && verificouStringInteira)
                    {
                        Console.WriteLine("ID inválido: " + idAtual);
                        Console.WriteLine("---------");
                        acumulador += ulong.Parse(idAtual);
                        break;
                    }

                }                

            }

        }
        return acumulador;
    }
}

