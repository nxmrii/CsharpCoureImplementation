using System.Xml.Linq;

namespace MiniFlightManagementSystem
{
    internal class Program
    {
        // variables
        //List
        static List<string> passengerNames = new List<string>();

        static List<String> ticketNumbers = new List<string>();

        static List<string> availableDates = new List<string>()
        {"7-Jan-2026","8-Jan-2026","9-Jan-2026","10-Jan-2026"};

        static List<string> cancelledTickets = new List<string>();

        //array
        static string[] flightNumbers = { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };

        //dictionary
        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>()
        {{ "T0" , "OA101|7-Jan-2026" },{ "T1" , "OA102|8-Jan-2026" },
         { "T2" , "OA103|9-Jan-2026" },{ "T3" , "OA104|10-Jan-2026" }};

        static Dictionary<string, string> passengerSeatMap = new Dictionary<string, string>()
        {{ "noor","1A"}, { "reem","2A"},{"deemah","3A" },
          { "habiba","4A"},{ "said","5A"}};

        //queue
        static Queue<string> checkedInQueue = new Queue<string>();
        static Queue<string> waitlistQueue = new Queue<string>();

        //stack
        static Stack<string> boardingStack = new Stack<string>();
        //------------------------------------------------------------------


        //cas1 --  Register New Passenger --  List
        static void registerPassenger()
        {
            Console.WriteLine("Enter passenger name: ");
            string name = Console.ReadLine();

            //validations
            //1- check if its empty
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can not be empty");
                return;
            }
            //2- check duplicate
            for (int i = 0; i < passengerNames.Count; i++)
            {
                if (passengerNames[i].ToLower() == name.ToLower())
                {
                    Console.WriteLine("passanger already exit");
                    return;
                }
            }

            //3- auto generate tiket id
            int nextnum = passengerNames.Count + 1;
            string Tid = "TKT-" + nextnum.ToString("D3");


            //4- add name anf tiket id in same list
            passengerNames.Add(name);
            ticketNumbers.Add(Tid);

            //5- view 
            Console.WriteLine("Passanger successfuly registerd..");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Ticket Id: " + Tid);

        }


        // case2 -- View All Passengers -- List
        static void viewAll()
        {
      
            //1- check if list is empty
            if (passengerNames.Count == 0)
            {
                Console.WriteLine("No passengers registered yet");
                return;
            }

            //2- for print
            Console.WriteLine("No.| Passenger Name| Ticket ID| Status");

            //3- loop to show the list
            for (int i = 0; i < passengerNames.Count; i++)
            {
                string name = passengerNames[i];
                string ticket = ticketNumbers[i];

                //4- chick if ticket is cancelled or active
                string Tstatus = "Active";
                if (cancelledTickets.Contains(ticket))
                {
                    Tstatus = "Cancelled";
                }

                //5- display 
                Console.WriteLine((i+1) + "\t" + name +  "\t"  + ticket + "\t" + Tstatus);
            }
            //6- display total passanger count 
            Console.WriteLine("total passenger: " + passengerNames.Count);

        }

        // case3 --  Book a Flight Ticket
        static void bookFlight()
        {
            //1- Enter ticket id
            Console.WriteLine("Enter ticket id: ");
            string ticket = Console.ReadLine();

            int ticketindex = -1;
            //2- check ticket exits 
            // search if it is exicet -- 
            for (int i=0; i < ticketNumbers.Count; i++)
            {
                if (ticketNumbers[i] == ticket)
                {
                    ticketindex = i;
                    break;
                }
            }
            // if it is not there it show this message
            if(ticketindex == -1)
            {
                Console.WriteLine("invalid ticket id");
                return;
            }

            // check cancell ticek
            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("This ticket canselled cannot booked!!");
                return;
            }

            // Check if the ticket is already in booking Record "dictionary"= containKeys
            if (bookingRecord.ContainsKey(ticket))
            {
                Console.WriteLine("alredy this ticket is booked");
                return;
            }

            //3- Display all available flight numbers
            Console.WriteLine("Available Flights");
            for(int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine(i + " ." + flightNumbers[i]);
            }

            Console.WriteLine("choose which flight by index: ");
            string flightchoose = Console.ReadLine();

            //4- Prompt the user to select a flight by entering its index number
            int flightindex;
            //using try - catch to convert string to int
            try
            {
                flightindex = Convert.ToInt32(flightchoose);
            }
            catch
            {
                Console.WriteLine("please enter a valid number");
                return;
            }
            //Validate the input is within range.

            if (flightindex < 0 || flightindex >= flightNumbers.Length) // e.x -> 8>=6 "invalid flight selection"
            {
                Console.WriteLine("Invalid flight number");
                return;
            }
            string selectflight = flightNumbers[flightindex]; // e.x -> 2 

            //5- display dates with index
            for(int i=0; i < availableDates.Count; i++)
            {
                Console.WriteLine(i + " ." + availableDates[i]);
            }
            Console.WriteLine("choose date by index: ");
            string dateinput = Console.ReadLine();

            int dateIndex;
            if(!int.TryParse(dateinput, out dateIndex)
                || dateIndex<0 || dateIndex>= availableDates.Count)
            {
                Console.WriteLine("invalid date selection");
                return;
            }

            string selectDate = availableDates[dateIndex];

            //6- Store the booking in bookingRecord with the ticket ID
            bookingRecord.Add(ticket, selectflight + "|" + selectDate);

            //7- Display a booking showing ticket ID, name, flight, date.
            
            Console.WriteLine("booking successful!");
            Console.WriteLine("passenger: " + passengerNames[ticketindex]);
            Console.WriteLine("ticket: " + ticket);
            Console.WriteLine("flight: " + selectflight);
            Console.WriteLine("date: " + selectDate);
        }






        static void PrintMenu()
        {
            Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
            Console.WriteLine("1.Register New Passenger");
            Console.WriteLine("2.View All Passengers");
            Console.WriteLine("3.Book a Flight Ticke");
            Console.WriteLine("4.View Booking Details");
            Console.WriteLine("5.Update a Booking");
            Console.WriteLine("6.Cancel a Ticket");
            Console.WriteLine("7.Passenger Check-In");
            Console.WriteLine("8.Board Passengers (Boarding Stack)");
            Console.WriteLine("9.Generate Flight Manifest");
            Console.WriteLine("10.Manage Waitlist & Seat Assignment");
            Console.WriteLine("0.Exi");
        }

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                PrintMenu();
                Console.Write("Enter your choice:  ");
                
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        registerPassenger();
                        break;

                    case 2:
                        viewAll();
                        break;

                    case 3:
                        bookFlight();
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

                    case 0:
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
