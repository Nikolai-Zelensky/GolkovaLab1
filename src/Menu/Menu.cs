using System;

namespace Dijkstra.OptionsMenu
{
    public class Menu
    {
        public string ShowMenu()
        {
            Console.WriteLine("1 - Короткий путь");
            Console.WriteLine("2 - Длинный путь");

            return Console.ReadLine();
        }

        public void StartMenu(DijkstraAlghoritm dijkstraAlghoritm)
        {
            switch (ShowMenu())
            {
                case "1":
                    {
                        Console.WriteLine("Введите откуда: ");
                        var from = Console.ReadLine();

                        Console.WriteLine("Введите куда: ");
                        var where = Console.ReadLine();

                        var path = dijkstraAlghoritm.FindShortestPathByName(from, where);

                        Console.WriteLine(path);
                        Console.ReadLine();
                        break;
                    }
                default:
                    Console.WriteLine("Не существует");
                    break;
            }
        }

    }
}
