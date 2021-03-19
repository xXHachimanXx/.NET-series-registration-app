using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        VisualizeSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thanks for use our services!");
            Console.ReadLine();
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series!!!");
            Console.WriteLine("Enter the desired option:");

            Console.WriteLine("1- List series");
            Console.WriteLine("2- Insert new serie");
            Console.WriteLine("3- Update serie");
            Console.WriteLine("4- Delete serie");
            Console.WriteLine("5- Visualize serie");
            Console.WriteLine("C- Clean screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }

        private static void DeleteSerie()
        {
            Console.Write("Enter with serie id: ");
            int serieIndex = int.Parse(Console.ReadLine());

            repository.Excludes(serieIndex);
        }

        private static void VisualizeSerie()
        {
            Console.Write("Enter with serie id: ");
            int serieIndex = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(serieIndex);

            Console.WriteLine (serie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Enter with serie id: ");
            int serieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof (Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof (Genre), i));
            }

            Console.Write("Enter the desired option: ");
            int inGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter with serie title: ");
            string inTitle = Console.ReadLine();

            Console.Write("Enter with serie year: ");
            int inYear = int.Parse(Console.ReadLine());

            Console.Write("Enter with serie description: ");
            string inDescription = Console.ReadLine();

            Serie updateSerie =
                new Serie(id: serieIndex,
                    genre: (Genre) inGenre,
                    title: inTitle,
                    year: inYear,
                    description: inDescription);

            repository.Update(serieIndex, updateSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("List series");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Anyone registered serie.");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.retornDeleted();

                Console
                    .WriteLine("#ID {0}: - {1} {2}",
                    serie.retornId(),
                    serie.retornTitle(),
                    (deleted ? "*Deleted*" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert new serie");

            foreach (int i in Enum.GetValues(typeof (Genre)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof (Genre), i));
            }

            Console.Write("Enter the desired option: ");
            int inGenre = int.Parse(Console.ReadLine());

            Console.Write("Enter with serie title: ");
            string inTitle = Console.ReadLine();

            Console.Write("Enter with serie year: ");
            int inYear = int.Parse(Console.ReadLine());

            Console.Write("Enter with serie description: ");
            string inDescription = Console.ReadLine();

            Serie newSerie =
                new Serie(id: repository.NextId(),
                    genre: (Genre) inGenre,
                    title: inTitle,
                    year: inYear,
                    description: inDescription);

            repository.Insert(newSerie);
        }
    }
}
