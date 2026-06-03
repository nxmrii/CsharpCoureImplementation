namespace ListPractice
{
    internal class Program
    {

        //case 1 -- Room Service Menu
        // Creating a list of string : initilaize
        static List<string> menuItems = new List<string>() {
            "pasta",
            "soup",
            "salad",
            "rice"
        };

        static void RoomService()
        {
            // Adding multiple elements at once 
            /*menuItems.AddRange(new string[] { 
            "pasta",
            "soup",
            "salad",
            "rice"
            
            });*/

            Console.WriteLine("Menu, display all items:");
            for (int i = 0; i < menuItems.Count; i++) { 
            Console.WriteLine((i+1) + ") " + menuItems[i]);
            }

            menuItems.AddRange("burger" , "fish");
            Console.WriteLine("updated menu, add 2 items:");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + menuItems[i]);
            }

            menuItems.Remove("pasta");
            Console.WriteLine("updated menu, remove one item:");
            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine((i + 1) + ") " + menuItems[i]);
            }

           
            Console.WriteLine("check if there is a fish in menu:");
            if(menuItems.Contains("fish"))
            {
                Console.WriteLine("yasss there is a fish in menu :)");
            }
            else
            {
                Console.WriteLine("im sorry there is no fish in menu :(");
            }

            Console.WriteLine("there is: " + menuItems.Count() + " items in menu");
        

        }

        //case 2 -- Guest Check-In Queue 




        //case 3 -- Housekeeping Floor Assignment 



        //case 4 -- Hotel Booking Conflict Resolver







        static void PrintMenu()
        {
            Console.WriteLine("LIST PRACTICE");
            Console.WriteLine("1.Room Service Menu");
            Console.WriteLine("2.Guest Check-In Queue");
            Console.WriteLine("3.Housekeeping Floor Assignment");
            Console.WriteLine("4.Hotel Booking Conflict Resolver");
            Console.WriteLine("5.Exit");
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
                        RoomService();
                        break;

                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
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
