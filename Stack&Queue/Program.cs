namespace Stack_Queue
{
    internal class Program
    {

        //case 1 -- Stack -- 
        //Browser History Tracker
        public static void BrowserHistory()
        {
            //1
            Stack<string> browserHistory = new Stack<string>();
            browserHistory.Push("https://github.com/nxmrii");
            browserHistory.Push("https://dotnettutorials.net");
            browserHistory.Push("https://www.bing.com");
            browserHistory.Push("https://www.msn.com");
            browserHistory.Push("https://www.youtube.com");

            //2
            foreach (string page in browserHistory) { 
            Console.WriteLine(page);
            }

            //3
            Console.WriteLine("View tha last visit: ");
            Console.WriteLine(browserHistory.Peek());

            //4
            Console.WriteLine("First removing: ");
            string pop1 = browserHistory.Pop();
            Console.WriteLine(pop1);
            Console.WriteLine("second removing: ");
            string pop2 = browserHistory.Pop();
            Console.WriteLine(pop2);

            //5
            Console.WriteLine("Display the remaining history after both pops:");
            foreach (string page in browserHistory)
            {
                Console.WriteLine(page);
            }

            //6
            Console.WriteLine("Check whether a youtube URL is still in the history? ");
            bool check = browserHistory.Contains("https://www.youtube.com");
            if (check == false)
            {
                Console.WriteLine("No, youtube is not in the history");
            }
            else
            {
                Console.WriteLine("still in the history..");
            }

            //7 
            Console.WriteLine("how many pages is still opening?");
            Console.WriteLine(browserHistory.Count() + " Pages");
        }

        //case 2 -- 



        //case 3 -- 


        //case 4 -- 







        static void PrintMenu()
        {
            Console.WriteLine("Stack & Queue Practice");
            Console.WriteLine("1.Browser History Tracker");
            Console.WriteLine("2.Hotel Check-In Queue");
            Console.WriteLine("3.Text Editor Undo System");
            Console.WriteLine("4.Hospital Emergency Room Triage");
            Console.WriteLine("5.Parenthesis Validator");
            Console.WriteLine("6.Print Spooler with Priority Re-Insertion");
            Console.WriteLine("7.Reverse a Sentence Word by Word");
            Console.WriteLine("8.Exit");
           
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
                        BrowserHistory();
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
