using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        const string AddDossier = "1"; 
        const string AllDossier = "2";
        const string DeletingDossier = "3";
        const string Exit = "4";

        Dictionary<string, string> listDossiers = new Dictionary<string, string>();
        bool isDatabaseActive = true;

        Console.WriteLine("База данных к вашим услугам, что желаете сделать?\n");

        while (isDatabaseActive)
        {
            Console.WriteLine($"{AddDossier} - Добавить досье.\n{AllDossier} - Вывести все досье.");
            Console.WriteLine($"{DeletingDossier} - Удалить досье.\n{Exit} - Выход.\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case AddDossier:
                    CreateDossier(listDossiers);
                    break;
                case AllDossier:
                    OutputAllDossiers(listDossiers);
                    break;
                case DeletingDossier:
                    DeleteDossier(listDossiers);
                    break;
                case Exit:
                    Console.Clear();
                    Console.WriteLine("Работа программы завершена.");
                    isDatabaseActive = false;
                    break;
                default:
                    Console.WriteLine("Ошибка! Неизвестная команда.");
                    break;
            }
        }
    }

    static void CreateDossier(Dictionary<string, string> listDossiers)
    {
        Console.Clear();
        Console.WriteLine("Введите Ф.И.О сотрудника:");
        string fullName = Console.ReadLine();

        if (listDossiers.ContainsKey(fullName) == false)
        {
            Console.WriteLine("Введите должность сотрудника:");
            string position = Console.ReadLine();

            listDossiers.Add(fullName, position);

            Console.WriteLine($"Успешно!\nНажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Ошибка!\nДанный сотрудник уже есть в базе данных.\nНажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void OutputAllDossiers(Dictionary<string, string> listDossiers)
    {
        Console.Clear();

        foreach (var dossier in listDossiers)
        {
            Console.WriteLine($"{dossier.Key} - {dossier.Value}");
        }

        Console.ReadKey();
        Console.Clear();
    }

    static void DeleteDossier(Dictionary<string, string> listDossiers)
    {
        Console.Clear();
        Console.WriteLine("Введите Ф.И.О Сотрудника, которого хотите удалить.");
        string fullName = Console.ReadLine();

        if (listDossiers.ContainsKey(fullName) == true)
        {
            listDossiers.Remove(fullName);
            Console.WriteLine("Успешно!\nНажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Грустно!\nДанного сотрудника нет в базе данных.\nНажмите любую кнопку, чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}