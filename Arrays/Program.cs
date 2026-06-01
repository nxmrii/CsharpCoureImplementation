namespace ArrayPractice
{
    internal class Program
    {
       




        static void PrintMenu()
        {
            Console.WriteLine("ARRAY PRACTICE");
            Console.WriteLine("1.Temperature Log");
            Console.WriteLine("2.Student Score Board  ");
            Console.WriteLine("3.Product Price Finder");
            Console.WriteLine("4.Race Finish Times");
            Console.WriteLine("5.Classroom Grade Report");
            Console.WriteLine("6.Warehouse Inventory Check");
            Console.WriteLine("7.Library Book Shelf Scanner");
            Console.WriteLine("8.Sales Performance Analyzer");
            Console.WriteLine("9.Flight Seat Allocation Display");
            Console.WriteLine("10.Hospital Patient Priority Queue");
            Console.WriteLine("11.Exit");
        }

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                PrintMenu();

                Console.Write("Choose option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
                        break;

                    case 11:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}