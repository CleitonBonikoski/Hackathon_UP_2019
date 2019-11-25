using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hackathon_UP_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Declarações

            // 1º forma de acessar o arquivo seria = @"C:\Hackathon_UP_2019\Hackathon_UP_2019\Doc\palavras.txt";
            // 2º forma de acessar o arquivo de forma dinamica:
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Doc\palavras.txt");
            string[] lstPalavras, plvDigitada;
            string plvDigOrd, plvModOrd;
            // Variável para medir tempo de execução.
            var watch = new Stopwatch();
            // Variável que irá validar os caracteres permitidos.
            Regex rgx = new Regex(@"^[a-zA-Z]");

            #endregion


            #region Coleta da(s) Palavra(s)

            Console.WriteLine("Informe a palavra:");
            // Irá ler a palavra ou frase digitada e separar por espaços.
            plvDigitada = Console.ReadLine().Split();
            Console.Clear();

            lstPalavras = File.ReadAllLines(path);

            //Iníco cálculo tempo de execução.
            watch.Start();

            foreach (var plv in plvDigitada)
            {
                if (!rgx.IsMatch(plv))
                {
                    Console.WriteLine("Erro caracter inválido na palavra {0}", plv);
                    Console.ReadKey();
                    return;
                }

            }

            #endregion


            #region Compara palavra

            Console.WriteLine("##  Combinações  ##");
            int count = 0;
            foreach (var plvDig in plvDigitada)
            {
                // Ordena a palavra digitada.
                plvDigOrd = String.Concat(plvDig.OrderBy(l => l)).ToUpper();
                foreach (var plvMod in lstPalavras)
                {
                    // Ordena a palavra modelo.
                    plvModOrd = String.Concat(plvMod.OrderBy(l => l)).ToUpper();

                    // caso exista a mesma quantidade de caracteres e sejam os mesmos caracteres então é possível gerar um re-arranjo.
                    if (plvDigOrd.Equals(plvModOrd))
                    {
                        // Soma qual é o número da combinação e mostra a palavra que está do Documento palavras.txt .
                        count++;
                        Console.WriteLine($"{count} Combinação: {plvMod}");
                    }
                }
            }
            watch.Stop();

            #endregion


            Console.WriteLine($"Tempo Execução em segundos: {watch.Elapsed.TotalSeconds.ToString()} ");

            Console.ReadKey();
        }

        
    }
}
