using ClassLibrary10lab;
using System.Diagnostics.Metrics;
namespace lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            MusicalInstrument[] instruments = new MusicalInstrument[20];

            for (int i = 0; i < 20; i++)
            {
                switch (rnd.Next(4))
                {
                    case 0:
                        {
                            instruments[i] = new Guitar();
                            instruments[i].Name = "Гитара";
                            (instruments[i] as Guitar).NumberOfStrings = rnd.Next(4, 12);
                            break;
                        }
                    case 1:
                        {
                            instruments[i] = new ElectricGuitar();
                            instruments[i].Name = "Электрогитара";
                            (instruments[i] as ElectricGuitar).NumberOfStrings = rnd.Next(4, 12);
                            (instruments[i] as ElectricGuitar).PowerSource = GetRandomPowerSource(rnd);
                            break;
                        }
                    case 2:
                        {
                            instruments[i] = new Piano();
                            instruments[i].Name = "Пианино";
                            (instruments[i] as Piano).KeyboardLayout = GetRandomKeyLayout(rnd);
                            (instruments[i] as Piano).NumberOfKeys = rnd.Next(61, 88);
                            break;
                        }
                    case 3:
                        {
                            instruments[i] = new Piano();
                            instruments[i].Name = "Пианино";
                            (instruments[i] as Piano).KeyboardLayout = GetRandomKeyLayout(rnd);
                            (instruments[i] as Piano).NumberOfKeys = rnd.Next(61, 88);
                            break;
                        }
                }
            }
            Console.WriteLine("\nЧасть 1");
            foreach (MusicalInstrument instrument in instruments)
            {
                instrument.Show();
            }

            //Часть 2 (запросы)
            Console.WriteLine("\nЧасть 2");
            //Запрос 1 (Среднее кол-во струн всех гитар)
            Console.WriteLine($"\\Среднее кол-во струн всех гитар: {QueryAverageNumberOfStrings(instruments)}");

            //Запрос 2 (Количество струн всех электрогитар c фиксированным источником питания)
            Console.WriteLine($"\\Количество струн всех электрогитар c фиксированным источником питания: {QueryNumberOfStringsFixedPowerSource(instruments)}");

            //Запрос 3 (Максимальное количество клавиш на фортепиано с октавной раскладкой)
            Console.WriteLine($"\\Максимальное количество клавиш на фортепиано с октавной раскладкой: {QueryMaxKeysOctaveLayout(instruments)}");


            //Часть 3 (работа с интерфейсами)
            Console.WriteLine("\nЧасть 3");

            IInit[] objectsArray = new IInit[10];
            for (int i = 0; i < 5; i++)
            {
                Student s = new Student();
                s.RandomInit();
                objectsArray[i] = (IInit)s;
            }
            for (int i = 5; i < 10; i++)
            {
                MusicalInstrument instrument = new MusicalInstrument();
                instrument.RandomInit();
                objectsArray[i] = (IInit)instrument;
            }
            foreach (IInit item in objectsArray)
            {
                Console.WriteLine(item);
            }
            int studentCount = objectsArray.Count(obj => obj is Student);
            int guitarCount = objectsArray.Count(obj => obj is Guitar);
            int pianoCount = objectsArray.Count(obj => obj is Piano);
            Console.WriteLine($"Число студентов: {studentCount}");
            Console.WriteLine($"Кол-во гитар: {guitarCount}");
            Console.WriteLine($"Кол-во пианино: {pianoCount}");
            
            // Создание объектов разных классов
            var instrumentsArray = new List<MusicalInstrument>
            {
                new Guitar("Акустическая гитара", 6),
                new ElectricGuitar("Электрогитара", 6, "Батарейки"),
                new Piano("Фортепиано", "Октавная", 88)
            };

            // Вывод элементов массива перед сортировкой
            Console.WriteLine("Массив до сортировки:");
            foreach (var instrument in instrumentsArray)
            {
                Console.WriteLine(instrument.Name);
            }

            // Сортировка элементов массива по имени
            instrumentsArray.Sort();

            // Вывод элементов массива после сортировки
            Console.WriteLine("\nМассив после сортировки:");
            foreach (var instrument in instrumentsArray)
            {
                Console.WriteLine(instrument.Name);
            }

            // Использование бинарного поиска в отсортированном массиве
            var searchIndex = instrumentsArray.BinarySearch(new Guitar("Электрогитара", 6), null);
            if (searchIndex >= 0)
            {
                Console.WriteLine($"\nИнструмент найден на позиции {searchIndex}");
            }
            else
            {
                Console.WriteLine("\nИнструмент не найден");
            }

        }

        static string GetRandomPowerSource(Random rnd)
        {
            string[] powerSources = { "Батарейки", "Аккумулятор", "Фиксированный источник питания", "USB" };
            return powerSources[rnd.Next(powerSources.Length)];
        }

        static string GetRandomKeyLayout(Random rnd)
        {
            string[] keyLayouts = { "Октавная", "Шкальная", "Дигитальная" };
            return keyLayouts[rnd.Next(keyLayouts.Length)];
        }

        //Часть 2 (запросы)
        //Запрос 1 (Среднее кол-во струн всех гитар)
        static double QueryAverageNumberOfStrings(MusicalInstrument[] instruments)
        {
            int totalStrings = 0;
            int guitarCount = 0;

            foreach (MusicalInstrument instrument in instruments)
            {
                if (instrument is Guitar)
                {
                    totalStrings += ((Guitar)instrument).NumberOfStrings;
                    guitarCount++;
                }
            }

            return guitarCount == 0 ? 0 : (double)totalStrings / guitarCount;
        }
        //Запрос 2 (Количество струн всех электрогитар c фиксированным источником питания)
        static int QueryNumberOfStringsFixedPowerSource(MusicalInstrument[] instruments)
        {
            int totalStrings = 0;

            foreach (MusicalInstrument instrument in instruments)
            {
                if (instrument is ElectricGuitar && ((ElectricGuitar)instrument).PowerSource == "Фиксированный источник питания")
                {
                    totalStrings += ((ElectricGuitar)instrument).NumberOfStrings;
                }
            }

            return totalStrings;
        }
        //Запрос 3 (Максимальное количество клавиш на фортепиано с октавной раскладкой)
        static int QueryMaxKeysOctaveLayout(MusicalInstrument[] instruments)
        {
            int maxKeys = 0;

            foreach (MusicalInstrument instrument in instruments)
            {
                if (instrument is Piano && ((Piano)instrument).KeyboardLayout == "Октавная" && ((Piano)instrument).NumberOfKeys > maxKeys)
                {
                    maxKeys = ((Piano)instrument).NumberOfKeys;
                }
            }

            return maxKeys;
        }
    }
    
}

