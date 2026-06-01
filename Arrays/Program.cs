namespace ArrayPractice
{
    internal class Program
    {

        //case 1 -- Temperature Log
        //array initilaization
        static Double[] temperatures = {0.1,0.2,0.3,0.4,0.5,0.6,0.7};
        static void temp() {
            //for loop + indexing
            for (int i = 0; i < temperatures.Length; i++) {

                Console.WriteLine("Day " + (i + 1) + ":" + temperatures[i] + "c");
            
            }

            Console.WriteLine("total number of stored tempretures: " + temperatures.Length);
        }


        //case 2 --  Student Score Board 
        // store scores in array , initialize
        static int[] scores = { 10, 20, 30, 40, 50, 100 };
        static void studentScores()
        {
            foreach (int i in scores) {
                Console.WriteLine("students scores is: " + i);
            }

            //Reverse the array and print it again.
            Array.Reverse(scores);
            Console.WriteLine("in reverse way: ");
            for (int i = 0; i < scores.Length; i++) {
                
                Console.WriteLine(scores[i]);
            }
        }


        // case 3 --  Product Price Finder 
        static Double[] prices = { 50, 60.5, 30, 40.5, 70 };
        static double prodictPrice(string key) { 
        
            for(int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine("Product " + (i+1) + ":" + prices[i]);
            }

            Array.IndexOf(prices);

                key = key;

                // check if keyword insid title 
                if (prices.Contains(key))
                {
                    return true;
                }

                return false;
            
        }









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
                        temp();
                        break;

                    case 2:
                        studentScores();
                        break;

                    case 3:
                        prodictPrice();
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