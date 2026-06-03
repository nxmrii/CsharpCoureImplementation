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
        static List<string> checkInQueue = new List<string>()
        {
            "noor",
            "reem",
            "deemah",
            "Arwa",
            "Habiba"
        };

        static void checkGuest()
        {
            Console.WriteLine("Guest Check in Queue: ");
            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine(checkInQueue[i]);
            }

            Console.WriteLine("Guest Check in Queue after removing the first guest: ");
            checkInQueue.RemoveAt(0);
            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine(checkInQueue[i]);
            }

            Console.WriteLine("Guest Check in Queue after removing the second guest: ");
            checkInQueue.RemoveAt(0);
            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine(checkInQueue[i]);
            }

            Console.WriteLine("Add 3 new arriving Guest");
            checkInQueue.AddRange("Asma", "Sara", "tasnim");
            for(int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine(checkInQueue[i]);
            }

            Console.WriteLine("check if Arwa is still waiting or not!");
            if (checkInQueue.Contains("Arwa"))
            {
                Console.WriteLine("Arwa still in waiting List");
            }
            else
            {
                Console.WriteLine("no one!");
            }

           Console.WriteLine("There is: " +  checkInQueue.Count + " still in the waiting list");
        }



        //case 3 -- Housekeeping Floor Assignment 
        static List<int> assignedRooms = new List<int>() {102,100,205,204,300,306};
        static void HousFloor()
        {
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine(assignedRooms[i]);
            }

            Console.WriteLine("Add 2 more room in the list");
            assignedRooms.AddRange(403, 404);
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine((i + 1) + ". Room " + assignedRooms[i]);
            }

            Console.WriteLine("remove room 403 from the list");
            assignedRooms.Remove(403);
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine(assignedRooms[i]);
            }

            Console.WriteLine("Sorted List: ");
            assignedRooms.Sort();
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine(assignedRooms[i]);
            }

            Console.WriteLine("display the index number for 204 room");
            int index = assignedRooms.IndexOf(204);
            Console.WriteLine(index);

            Console.WriteLine("put 120 in the index 2");
             assignedRooms.Insert(2 , 120);
            for (int i = 0; i < assignedRooms.Count; i++)
            {
                Console.WriteLine(assignedRooms[i]);
            }

            Console.WriteLine("Total Rooms: " + assignedRooms.Count);


        }

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
                        checkGuest();
                        break;

                    case 3:
                        HousFloor();
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
