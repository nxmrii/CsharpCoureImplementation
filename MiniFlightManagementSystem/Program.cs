using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        // case3 --  book a Flight Ticket
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
            /*if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("This ticket canselled cannot booked!!");
                return;
            }*/
            if (cancelledTickets.Contains(ticket))
            {
                cancelledTickets.Remove(ticket);
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


        //case4 --  View Booking Details
        static void viewBookingdetails()
        {
            Console.WriteLine("Enter Ticket Id: ");
            string ticket = Console.ReadLine();

            //1  Prompt for a ticket ID. with validate
            //if empty
                if (string.IsNullOrEmpty(ticket))
                {
                    Console.WriteLine("ticket id can not be empty");
                    return;
                }

                //if not found
                if (!ticketNumbers.Contains(ticket))
            {
                Console.WriteLine("Ticket ID not found");
                return;
            }

            //find matching index
            int index = ticketNumbers.IndexOf(ticket);
            string passenger = passengerNames[index];

            //check if ticket is cancelled
            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("This ticket cancelled");
                return;
            }

            //if the ticket id not match in the booking record
            if (!bookingRecord.ContainsKey(ticket)){
                Console.WriteLine("No booking found for this ticket");
                return;
            }

            //get booking value
            string booking = bookingRecord[ticket];

            //split the booking value
            string[] parts = booking.Split("|");
            // store flight and value
            string flightNumb = parts[0];
            string flightDate = parts[1];

            //display booking summary
            Console.WriteLine("Booking Summary");
            Console.WriteLine("Passanger: " + passenger);
            Console.WriteLine("Ticket ID: " + ticket);
            Console.WriteLine("Flight Number: " + flightNumb);
            Console.WriteLine("Flight Date: " + flightDate);

        }

        //case5 --  Update a Booking
        static void updateBooking()
        {
            //1
            Console.WriteLine("Enter Ticket id: ");
            string ticket = Console.ReadLine();

            if (!ticketNumbers.Contains(ticket))
            {
                Console.WriteLine("Ticket ID not found.");
                return;
            }

            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("This ticket is cancelled");
                return;
            }

            if (!bookingRecord.ContainsKey(ticket))
            {
                Console.WriteLine("this ticket id not exists");
                return;
            }

            //2
            string booking = bookingRecord[ticket];
            string[] details = booking.Split('|');
            string CurrentFlight = details[0];
            string CuurentDate = details[1];

            Console.WriteLine("Current Booking Details");
            Console.WriteLine("Ticket ID: " + ticket);
            Console.WriteLine("Flight Number: " + CurrentFlight);
            Console.WriteLine("Flight Date: " + CuurentDate);

            //3
            SupMenu();
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();


            //save old value before updating
            string oldFlight = CurrentFlight;
            string oldDate = CuurentDate;

            string newFlight = CurrentFlight;
            string newDate = CuurentDate;

            switch (option)
            {
                //1.Change flight only
                case "1":
                    Console.WriteLine("Available Flights: ");
                    for (int i = 0; i < flightNumbers.Length; i++)
                    {
                        Console.WriteLine(flightNumbers[i]);
                    }

                    Console.Write("Enter new flight: ");
                    newFlight = Console.ReadLine().Trim();

                    //check if flight is there or not
                    if (!flightNumbers.Contains(newFlight))
                    {
                        Console.WriteLine("Invalid flight.");
                        return;
                    }
                    newDate = CuurentDate;
                    Console.WriteLine("Successfuly updated flight..");
                    break;

                //2.Change Date Only
                case "2":

                    Console.WriteLine("Available Dates: ");
                    for (int i = 0; i < availableDates.Count; i++)
                    {
                        Console.WriteLine(availableDates[i]);
                    }

                    Console.Write("Enter new date: ");
                    newDate = Console.ReadLine().Trim();

                    //check if date is there or not
                    if (!availableDates.Contains(newDate))
                    {
                        Console.WriteLine("Invalid Date.");
                        return;
                    }
                    newFlight = CurrentFlight;
                    Console.WriteLine("Successfuly updated date..");
                    break;

                //3.Change Both
                case "3":
                    //show available flight
                    Console.WriteLine("Available Flights: ");
                    for (int i = 0; i < flightNumbers.Length; i++)
                    {
                        Console.WriteLine(flightNumbers[i]);
                    }

                    Console.Write("Enter new flight: ");
                    string bothFlight = Console.ReadLine().Trim();

                    //check if flight is there or not
                    if (!flightNumbers.Contains(bothFlight))
                    {
                        Console.WriteLine("Invalid flight.");
                        return;
                    }

                    //show available dates
                    Console.WriteLine("Available Dates: ");
                    for (int i = 0; i < availableDates.Count; i++)
                    {
                        Console.WriteLine(availableDates[i]);
                    }

                    Console.Write("Enter new date: ");
                    string bothDate = Console.ReadLine().Trim();

                    //check if date is there or not
                    if (!availableDates.Contains(bothDate))
                    {
                        Console.WriteLine("Invalid Date.");
                        return;
                    }

                    // assign both updates
                    newFlight = bothFlight;
                    newDate = bothDate;

                    Console.WriteLine("Successfully updated both flight and date.");
                    break;

                //0.Cancel Update
                case "0":
                    Console.WriteLine("Update cancelled.");
                    break;
            }

            //FLIGHT|DATE
            string updatedBooking = newFlight + "|" + newDate;
            bookingRecord[ticket] = updatedBooking;

            Console.WriteLine("Booking Updated Successfully");
            Console.WriteLine("OLD BOOKING");
            Console.WriteLine("Flight: " + oldFlight);
            Console.WriteLine("Date  : " + oldDate);
            
            Console.WriteLine("NEW BOOKING");
            Console.WriteLine("Flight: " + newFlight);
            Console.WriteLine("Date  : " + newDate);
        }


        //case 6 --  Cancel a Ticket
        static void cancelTicket()
        {
            //1
            Console.WriteLine("Enter Ticket Id: ");
            string ticket = Console.ReadLine();

            if (!ticketNumbers.Contains(ticket))
            {
                Console.WriteLine("ticket invalid");
                return;
            }

            if (cancelledTickets.Contains(ticket))
            {
                Console.WriteLine("Ticket is cancelled");
                return;
            }

            //2 get passanger name by ticket index
            int index = ticketNumbers.IndexOf(ticket);
            string passanger = passengerNames[index];

            //3 remove booking
            string removedBooking = "";

            if (bookingRecord.ContainsKey(ticket))
            {
                removedBooking = bookingRecord[ticket];
                bookingRecord.Remove(ticket);
            }

            //cancelledTickets.Add(ticket);
            Console.WriteLine("Ticket cancelled successfuly..");

            //5 create a new queue and remove from the old queue
            bool removeinqueue = false;  //to know if the passanger is delete or not
            Queue<string> tqueue = new Queue<string>();
            while (checkedInQueue.Count > 0)
            {
                string person = checkedInQueue.Dequeue(); //remove first passanger from queue

                //if the passsanger not the person who you want delete,add to temp queue 
                if (person != passanger)
                {
                    tqueue.Enqueue(person);
                }
                //if it is the passanger who you want delete dont add to temp queue just tell that is find
                else
                {
                    removeinqueue = true;
                }
            }
            while (tqueue.Count > 0)
                {
                    checkedInQueue.Enqueue(tqueue.Dequeue());
                }
                if (removeinqueue)
                {
                    Console.WriteLine("Passenger removed from check-in queue.");
                }
            


            //6 Create temporary stacks

            bool removedFromStack = false;

            Stack<string> tempStack = new Stack<string>();
            Stack<string> rebuildStack = new Stack<string>();

            while (boardingStack.Count > 0)
            {
                string person = boardingStack.Pop();

                if (person != passanger)
                {
                    tempStack.Push(person);
                }
                else
                {
                    removedFromStack = true;
                }
            }

            while (tempStack.Count > 0)
            {
                rebuildStack.Push(tempStack.Pop());
            }

            while (rebuildStack.Count > 0)
            {
                boardingStack.Push(rebuildStack.Pop());
            }

            if (removedFromStack)
            {
                Console.WriteLine("Passenger removed from boarding stack.");
            }

            //7
            Console.WriteLine("Cancellation Summary");

            Console.WriteLine("Ticket ID: " + ticket);
            Console.WriteLine("Passenger: " + passanger);
            Console.WriteLine("Status: Cancelled");

            Console.WriteLine("Booking Removed: " + removedBooking);

            if (removeinqueue)
            {
                Console.WriteLine("Removed from Check-In Queue: Yes");
            }
            else
            {
                Console.WriteLine("Removed from Check-In Queue: No");
            }

            if (removedFromStack)
            {
                Console.WriteLine("Removed from Boarding Stack: Yes");
            }
            else
            {
                Console.WriteLine("Removed from Boarding Stack: No");
                
            }

           
           
        }



        //case 7 -- Passenger Check-In -- queue
        static void chekIn() {
            
            shortMenu();
            Console.Write("Choose an option: ");
            string check = Console.ReadLine();

            switch (check) {

                //1.Check in a passenger
                case "1":
                    //2- prompt for ticket ID, validate it exists and is not cancelled,
                    Console.WriteLine("Enter Ticket id: ");
                    string ticket = Console.ReadLine();

                    if (!ticketNumbers.Contains(ticket))
                    {
                        Console.WriteLine("Ticket ID not found.");
                        return;
                    }

                    if (cancelledTickets.Contains(ticket))
                    {
                        Console.WriteLine("This ticket is cancelled");
                        return;
                    }

                   // confirm a booking exists in bookingRecord,
                    if (!bookingRecord.ContainsKey(ticket))
                    {
                        Console.WriteLine("this ticket id not exists");
                        return;
                    }
                    
                    int index = ticketNumbers.IndexOf(ticket);
                    string passenger = passengerNames[index];

                    // confirm the passenger is not already in the queue
                    if (checkedInQueue.Contains(passenger))
                    {
                        Console.WriteLine("Passenger already in queue.");
                        return;
                    }
                    //3- Count is less than 10: retrieve the passenger name and enqueue it to checkedInQueue.
                    if (checkedInQueue.Count < 10)
                    {
                        checkedInQueue.Enqueue(passenger);
                        Console.WriteLine("Passenger checked in successfully.");
                    }
                    //4-.Count equals 10: enqueue the passenger name to waitlistQueue i
                    else
                    {
                        waitlistQueue.Enqueue(passenger);
                        Console.WriteLine("Check-In Queue Full.\r\nAdded to Waitlist Queue.");
                    }
                        break;

                //2.View check-in queue
                //display all passengers currently in checkedInQueue using foreach with position labels,
                //and display the waitlist count
                case "2":
                    int pos = 1;
                    foreach(string p in checkedInQueue)
                    {
                        Console.WriteLine(pos + ". " + p);
                        pos++;
                    }
                    Console.WriteLine("WaitList count: " + waitlistQueue.Count);
                break;

                //3.Process next passenger
                //if the queue is not empty, dequeue the front passenger and display their name as processed.
                //If the waitlist is not empty, automatically move the front waitlist passenger into checkedInQueue.
                case "3":
                    if(checkedInQueue.Count == 0)
                    {
                        Console.WriteLine("Queue is empty");
                        return;
                    }
                    string frontPassanger = checkedInQueue.Dequeue();
                    Console.WriteLine("Processed: " + frontPassanger);

                    if(waitlistQueue.Count > 0)
                    {
                        string nextPassenger = waitlistQueue.Dequeue();
                        checkedInQueue.Enqueue(nextPassenger);
                        Console.WriteLine(nextPassenger + "Moved from wait List to check in queue..");
                    }
                break;

                //0.Back
                case "0":
                Console.WriteLine("back.");
                break;
            }
        }


        //cas 8 --  Board Passengers (Boarding Stack)
        static int currentRow = 10;
        static char currentSeat = 'A';
        static void BoardPassengers()
        {
            boardMenu();
            Console.Write("Choose an option: ");
            string ckick = Console.ReadLine();

            switch (ckick)
            {

                //Load Boarding Stack = Queue-> stack
                case "1":
                    if (boardingStack.Count > 0 && checkedInQueue.Count == 0)
                    {
                        Console.WriteLine("Already loaded");
                        break;
                    }
                    int count = 0;
                    while (checkedInQueue.Count > 0)
                    {
                        string passenger = checkedInQueue.Dequeue();
                        boardingStack.Push(passenger);
                        count++;
                    }
                    Console.WriteLine($"{count} passengers loaded.");
                    break;


                //Board next passenger
                case "2":
                    // if boardingStack is not empty, pop the top passenger.
                    if(boardingStack.Count == 0)
                    {
                        Console.WriteLine("No passengers in boarding stack");
                        break;
                    }
                    string passengers = boardingStack.Pop();

                    string seat = currentRow.ToString() + currentSeat;
                    //Store the assignment in passengerSeatMap.
                    //passengerSeatMap.Add(passengers, seat);
                    // Display the passenger name and assigned seat.
                    Console.WriteLine($"{passengers} boarded. Seat: {seat}");

                    //to go next seat
                    if (currentSeat < 'F')
                    {
                        currentSeat++; //A > B > C ...
                    }
                    else
                    {
                        currentSeat = 'A';
                        currentRow++;
                    }
                    break;

                case "3":
                    if(boardingStack.Count == 0)
                    {
                        Console.WriteLine("boarding stack is empty");
                        break;
                    }

                    //display the stack
                    int postion = 1;
                    foreach (string passengr in boardingStack)
                    {
                        Console.WriteLine(postion  + ". " + passengr);
                        postion++;
                    }
                    break;

                case "4":
                    //iterate over passengerSeatMap and display each passenger name with their assigned seat
                    if (passengerNames.Count == 0)
                    {
                        Console.WriteLine("no borading record..");
                        break;
                    }
                    foreach (var passenger in passengerSeatMap)
                    {
                        Console.WriteLine($"{passenger.Key} , { passenger.Value}");
                    }
                    
                    break;

                //0.Back
                case "0":
                    Console.WriteLine("back.");
                    break;
            }
        }







        //--------------------------------------------------------------
        //helper functions 
        //for case 5
        static void SupMenu()
        {
            Console.WriteLine("Updating");
            Console.WriteLine("1.Change flight only");
            Console.WriteLine("2.Change Date Only");
            Console.WriteLine("3.Change Both");
            Console.WriteLine("0.Cancel Update");

        }

        //for case 7
        static void shortMenu()
        {
            Console.WriteLine("Passenger Check-In");
            Console.WriteLine("1.Check in a passenger");
            Console.WriteLine("2.View check-in queue");
            Console.WriteLine("3.Process next passenger");
            Console.WriteLine("0.Back");
        }

        static void PrintMenu()
        {
            Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
            Console.WriteLine("1.Register New Passenger");//done
            Console.WriteLine("2.View All Passengers");//done
            Console.WriteLine("3.Book a Flight Ticke");//done
            Console.WriteLine("4.View Booking Details");//done
            Console.WriteLine("5.Update a Booking");//done
            Console.WriteLine("6.Cancel a Ticket");//done
            Console.WriteLine("7.Passenger Check-In");//done
            Console.WriteLine("8.Board Passengers (Boarding Stack)");//in the way
            Console.WriteLine("9.Generate Flight Manifest");
            Console.WriteLine("10.Manage Waitlist & Seat Assignment");
            Console.WriteLine("0.Exi");
        }

        static void boardMenu()
        {
            Console.WriteLine("Boarding Menu");
            Console.WriteLine("1.Load boarding stack from check-in queue");
            Console.WriteLine("2.Board next passenger");
            Console.WriteLine("3.View boarding stack");
            Console.WriteLine("4.View boarding log");
            Console.WriteLine("0.Back");

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
                        viewBookingdetails();
                        break;

                    case 5:
                        updateBooking();
                        break;

                    case 6:
                        cancelTicket();
                        break;

                    case 7:
                        chekIn();
                        break;

                    case 8:
                        BoardPassengers();
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
