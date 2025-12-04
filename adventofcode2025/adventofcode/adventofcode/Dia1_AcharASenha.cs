using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode;

public static class Dia1_AcharASenha
{
    private static char[] chars = ['R', 'r', 'L', 'l'];

    public static int AcharSenha1(int valorInicial, string codigo)
    {
        int solucao = 0;

        if (codigo.Length == 0)
        {
            return 0;
        }

        while(codigo.Length > 0)
        {
            char direcao = codigo[codigo.IndexOfAny(chars)];
            string codigoSemDirecao = codigo.Substring(codigo.IndexOf(direcao) + 1);
            int casasParaPegar = codigoSemDirecao.IndexOfAny(chars) == -1 ? codigoSemDirecao.Length : codigoSemDirecao.IndexOfAny(chars);
            string valor = codigoSemDirecao.Substring(0, casasParaPegar);
            codigo = codigo.Remove(0, casasParaPegar + 1);

            Console.WriteLine("---------------");
            Console.WriteLine("Direcao: " + direcao);
            Console.WriteLine("Codigo sem direcao: " + codigoSemDirecao);
            Console.WriteLine("Valor:" + valor);
            Console.WriteLine("Codigo restante:" + codigo);
            Console.WriteLine();

            int valorInt = int.Parse(valor);

            if (valorInt > 100)
            {
                valorInt = valorInt % 100;
            }

            int resultado = 0;
            if (direcao == 'R' || direcao == 'r')
            {
                resultado = valorInicial + valorInt;
                resultado = resultado > 100 ? resultado -= 100 : resultado;

            }
            else if (direcao == 'L' || direcao == 'l')
            {
                resultado = valorInicial - valorInt;
                resultado = resultado < 0 ? resultado += 100 : resultado;
            }
            Console.WriteLine("Resultado: " + resultado);

            if (resultado == 0 || resultado == 100 || resultado == -100)
            {
                solucao++;
                resultado = 0;
            }            
            valorInicial = resultado;            
        }        
        return solucao;
    }

    public static int AcharSenha2(int valorInicial, string codigo)
    {
        int solucao = 0;

        if (codigo.Length == 0)
        {
            return 0;
        }

        while (codigo.Length > 0)
        {
            char direcao = codigo[codigo.IndexOfAny(chars)];
            string codigoSemDirecao = codigo.Substring(codigo.IndexOf(direcao) + 1);
            int casasParaPegar = codigoSemDirecao.IndexOfAny(chars) == -1 ? codigoSemDirecao.Length : codigoSemDirecao.IndexOfAny(chars);
            string valor = codigoSemDirecao.Substring(0, casasParaPegar);
            codigo = codigo.Remove(0, casasParaPegar + 1);

            Console.WriteLine("---------------");
            Console.WriteLine("Direcao: " + direcao);
            Console.WriteLine("Codigo sem direcao: " + codigoSemDirecao);
            Console.WriteLine("Valor:" + valor);
            Console.WriteLine("Codigo restante:" + codigo);
            Console.WriteLine();

            int valorInt = int.Parse(valor);

            if(valorInicial > 100) 
            { 
                int qtdVoltasInicial = (int) valorInicial / 100;
                Console.WriteLine("Qtd voltas inicial " + qtdVoltasInicial);
                solucao += qtdVoltasInicial;
                valorInicial = valorInicial % 100;
                Console.WriteLine("Valor inicial " + valorInicial);
                Console.WriteLine("Solução inical: " + solucao);
            }
            
            if (valorInt > 100)
            {
                int qtdVoltas = (int) valorInt / 100;
                Console.WriteLine("Qtd voltas: " + qtdVoltas);
                solucao += qtdVoltas;

                valorInt = valorInt % 100;
                Console.WriteLine("Resto: " + valorInt);
            }

            int resultado = 0;

            if (direcao == 'R' || direcao == 'r')
            {
                Console.WriteLine("Valor inicial: " + valorInicial);
                resultado = valorInicial +  valorInt;
                if(resultado == 100)
                {
                    solucao++;
                    resultado = 0;                   
                }
                else  if (resultado >= 100)
                {
                    
                    solucao++;
                    resultado -= 100;
                }
            }
            else if (direcao == 'L' || direcao == 'l')
            {    
                resultado = valorInicial - valorInt;
                if (resultado <= 0)
                {
                    if(valorInicial != 0)
                        solucao++;
                    resultado += 100;
                    if(resultado == 100)
                    {
                        resultado = 0;
                    }
                }
               
            }
           
            Console.WriteLine("Resultado: " + resultado);           
            Console.WriteLine("Solução: " + solucao );
            valorInicial = resultado;
        }
        return solucao;
    }
}
