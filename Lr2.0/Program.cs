using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Создание текстового файла с произвольным числом строк
        string filePath = "example.txt";
        CreateTextFile(filePath);

        // Чтение и вывод содержимого файла
        Console.WriteLine("Содержимое файла:");
        DisplayFileContent(filePath);

        // Определение сочетания двух первых символов
        CountFirstTwoCharsOccurrences(filePath);
    }

    static void CreateTextFile(string filePath)
    {
        // Пример строк для записи в файл
        string[] lines = {
            "Привет, мир!",
            "Программирование на C# - это преинтересно.",
            "Привет, как дела?",
            "Мир полон возможностей. ПР",
            "Программирование - это пр искусство."
        };

        // Запись строк в файл
        File.WriteAllLines(filePath, lines);
        Console.WriteLine($"Файл '{filePath}' успешно создан.");
    }

    static void DisplayFileContent(string filePath)
    {
        // Чтение строк из файла
        string[] lines = File.ReadAllLines(filePath);

        // Вывод строк в консоль
        foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine(); // Пустая строка для удобства
    }

    static void CountFirstTwoCharsOccurrences(string filePath)
    {
        // Чтение всех строк из файла
        string[] lines = File.ReadAllLines(filePath);

        // Проверка, есть ли хотя бы одна строка
        if (lines.Length == 0)
        {
            Console.WriteLine("Файл пуст.");
            return;
        }

        // Получение первых двух символов первой строки
        string firstTwoChars = lines[0].Substring(0, Math.Min(2, lines[0].Length)).ToLower();
        int count = 0;

        // Подсчет вхождений сочетания первых двух символов
        foreach (string line in lines)
        {
            // Подсчет всех вхождений сочетания первых двух символов в строке без учета регистра
            string lowerLine = line.ToLower();
            int index = lowerLine.IndexOf(firstTwoChars);
            while (index != -1)
            {
                count++;
                index = lowerLine.IndexOf(firstTwoChars, index + 1);
            }
        }

        Console.WriteLine($"Сочетание '{firstTwoChars}' встречается {count} раз(а) в файле.");
    }
}