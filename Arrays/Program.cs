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
        static void prodictPrice() { 
        
            for(int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine("Product " + (i+1) + ":" + prices[i]);
            }
            
            double target = 60.5;  // hardcoded target
            int index = Array.IndexOf(prices,target);  // indexOf: true= 1, false=-1

            // check in wich index 
            if (index != -1)
            {
                Console.WriteLine("Price " + target + " found in index " + index);
            }
            else {
                Console.WriteLine("Price " + target+ " was not found");
            }
        }


        // case 4 -- Race Finish Times
        static int[] finishTimes = {10,15,11,13,16,14,12,17};
        //print orginal array
        static void raceFinishTime()
        {
            foreach (int i in finishTimes) {

                Console.WriteLine(i);
            }

            // sorted

            //int sortetimes = Array.Sort(finishTimes); // first i do this mistake and i understand that the array.sort "void" not return any value
            Array.Sort(finishTimes);
            Console.WriteLine("sorted times: ");
            foreach (int time in finishTimes)
            {

                Console.WriteLine(time);
            }

            Console.WriteLine("number of players: " + finishTimes.Length);
        }


        //case 5 -- Classroom Grade Report 
        static int[] grades = { 60, 70, 50, 30, 20, 98, 83, 77, 99, 100 };
        static void studenGrade()
        {
            Array.Sort(grades);
            Array.Reverse(grades);

            for (int i = 0; i < grades.Length; i++) {

                Console.WriteLine("Ranke " + (i + 1) + ": " + grades[i]);
            }
           
        }


        //case 6 -- Warehouse Inventory Check
        static int[] quantities = { 5, 6, 7, 2, 4, 10, 8, 9 };
        static void totQuantities() {

            //total
            int total = 0;
            for (int i = 0; i < quantities.Length; i++) {

                total += quantities[i];
            }
            Console.WriteLine("total quantities: " +  total);

            //avrage
            double avrage = total / quantities.Length;
            Console.WriteLine("Avrage quantity: " + avrage);
        }


        //case 7 -- Library Book Shelf Scanner
        static int[] copies = {7,9,0,3,4,5,10,16,25};
        static void totCopies() {

            foreach (int i in copies)
            { 
            Console.WriteLine(i);
            }

            Array.Sort(copies);
            Console.WriteLine("sorted copies: ");
            foreach (int cop in copies)
            {
                Console.WriteLine(cop);
            }
            Console.WriteLine("the most title copies: " + copies[copies.Length - 1]);


            //q:Check whether any entry equals zero and report accordingly. i try to solve it without using for loop
            int founMax = Array.Find(copies, (i) => i <= 0);
            Console.WriteLine("find zero copies without using for loop: " + founMax);

            //using for loop
            for (int i = 0; i < copies.Length; i++)
            {
                if (copies[i] == 0)
                {
                    Console.WriteLine("There is a book title with zero copies");
                    break;
                }
                else
                {
                    Console.WriteLine("there is no book title with zero copies");
                }
            }


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
                        raceFinishTime();

                        break;

                    case 5:
                        studenGrade();
                        break;

                    case 6:
                        totQuantities();
                        break;

                    case 7:
                        totCopies();
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