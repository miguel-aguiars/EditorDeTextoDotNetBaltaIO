using System.IO;
using System;
Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Abrir arquivo");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("0 - Sair");
    short option = short.Parse(Console.ReadLine());

    switch (option)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Open(); break;
        case 2: Edit(); break;
        default: Menu(); break;
    }
}

static void Open()
{
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo?");

    string path = Console.ReadLine();

    using (var file = new StreamReader(path)) //Abre e fecha arquivo
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

static void Edit()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo (ESC para sair) ");
    Console.WriteLine("----------------------------");
    string text = "";


    do
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Save(text);
}

static void Save(string text)
{
    Console.Clear();
    Console.WriteLine("Qual caminho deseja salvar o arquivo?");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path)) //Abre e fecha arquivo
    {
        file.Write(text);
    }

    Console.WriteLine($"O arquivo foi salvo no caminho {path} com sucesso!");
    Console.ReadLine();
    Menu();
}