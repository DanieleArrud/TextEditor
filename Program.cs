using System;
using System.IO;
using System.Threading;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Editor de Texto");

            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que fará hoje?");

            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Novo arquivo");
            Console.WriteLine("3 - Sair");

            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: Console.WriteLine("Abrindo arquivo");
                    Thread.Sleep(1000);
                    Abrir();
                    break;
                case 2: Console.WriteLine("Novo arquivo sendo criado!");
                    Thread.Sleep(1000);
                    Editar();
                    break;
                case 3: Console.WriteLine("Você saiu!");
                    System.Environment.Exit(0);
                    break;
                default: Console.WriteLine("Não entendi");
                    Thread.Sleep(1000);
                    Menu();
                    break;
            }
        }

        static void Abrir() 
        {
            Console.Clear();
            Console.WriteLine("-------(ESC para sair)--------");

            Console.WriteLine("");

            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
                Console.WriteLine("");
            Console.ReadLine();
            


        }

        static void Editar() 
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Uh, surgiu ideia nova?");
            Console.WriteLine("-------(ESC para sair)--------");

            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("");
            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminha para salvar o arquivo?");

            var path = Console.ReadLine();

            using (var file = new StreamWriter(path)) 
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo em {path} com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
