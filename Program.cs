/*ДЗ. Напишите программу «Простейший файловый менеджер».
Возможности:
1. Смена текущего каталога (путь к текущему каталогу должен всегда отображаться на экране);
2. Отображение всех подкаталогов текущего каталога;
3. Отображение всех файлов текущего каталога;
4. Создание нового каталога в текущем каталоге;
5. Удаление уже существующего каталога (если каталог не пустой — то необходимо удалить все его содержимое, для этого Вам необходимо использовать  рекурсию)
*/
using System;
using System.IO;

namespace FileManG
{
    class Program
    {
        static void Main(string[] args)
        {
            var choice = 0;

            do
            {
                Console.WriteLine("Выберите действие :\nВыбрать(сменить) каталог(1)\nОтобразить все подкаталоги(2)\nОтобразить все файлы(3)\nСоздать каталог(4)\nУдалить каталог(5)\nЗвершить программу(0)");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введите путь к каталогу");
                        var path = Console.ReadLine();
                        Directory.SetCurrentDirectory(path);
                        DirectoryInfo dirName = new DirectoryInfo(path);
                        Console.WriteLine($"{dirName.FullName}");
                        break;
                    case 2:
                        string dir = Directory.GetCurrentDirectory();
                        Console.WriteLine($"{dir}");
                        string[] dirs = Directory.GetDirectories(dir);
                        foreach (var item in dirs)
                        {
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case 3:
                        string dir1 = Directory.GetCurrentDirectory();
                        Console.WriteLine($"{dir1}");
                        string[] files = Directory.GetFiles(dir1);
                        foreach (var item in files)
                        {
                            Console.WriteLine($"{item}");
                        }
                        break;
                    case 4:
                        path = Directory.GetCurrentDirectory();
                        Console.WriteLine("Введите название каталога");
                        var subpath = Console.ReadLine();
                        DirectoryInfo dirInfo = new DirectoryInfo(path);
                        if (!dirInfo.Exists)
                        {
                            dirInfo.Create();
                        }
                        dirInfo.CreateSubdirectory(subpath);
                        break;
                    case 5:
                        Console.WriteLine("Введите название каталога");
                        path = Console.ReadLine();
                        DirectoryInfo ctlg = new DirectoryInfo(path);


                        if (ctlg.Exists)
                        {
                            ctlg.Delete(true);

                        }
                        break;
                }

            } while (choice != 0);

        }
        static void EmtyDirectDel(string way)
        {
            if (Directory.GetDirectories(way).Length + Directory.GetFiles(way).Length == 0)
            {
                DirectoryInfo dir = new DirectoryInfo(way);
                dir.Delete();
                
            }
            else
            {
                var dir = new DirectoryInfo(way);
                var files = dir.GetFiles();

                foreach(var item in files)
                {
                    item.Delete();
                }
                dir.Delete();
            }
                
        }
    }
}
