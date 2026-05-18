namespace HotelManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string guestName = "";
            string gustPhone = "";
            int rommNum = 0;
            string roomType = "";
            double nightlyRate = 0;
            DateTime checkIndate;
            DateTime checkOutdate;
            int numOfNights = 0;
            string roomNotes = "";
            double discountPersntage = 0;
            int loyaltyPoints = 0;

            bool isGuestRegister = false;
            bool isCheckIn = false;

            int choice = 0;

            while (true)
            {

                Console.WriteLine("0. Register New Guest");
                Console.WriteLine("1. View Guest Information");
                Console.WriteLine("2. Check-In Guest");
                Console.WriteLine("3. Check-Out & Bill");
                Console.WriteLine("4. Apply Discount");
                Console.WriteLine("5. Upgrade Room");
                Console.WriteLine("6. Add Room Service Note");
                Console.WriteLine("7. Search Guest by Name");
                Console.WriteLine("8. Calculate Loyalty Points");
                Console.WriteLine("9. Print Receipt");
                Console.WriteLine("10. Edit Guest Name");
                Console.WriteLine("11. Exit");
                Console.Write("Enter ur choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    // register guest = Add
                    case 0:

                        // Trim = remove the space between 
                        Console.Write("Enter guest name: ");
                        guestName = Console.ReadLine();
                        guestName = guestName.Trim();


                        Console.Write("Enter guest phone: ");
                        gustPhone = Console.ReadLine();
                        gustPhone = gustPhone.Trim();

                        Console.Write("Enter room type: ");
                        roomType = Console.ReadLine();
                        roomType = roomType.Trim();

                        Console.Write("Enter Nightly rate: ");
                        nightlyRate = Convert.ToDouble(Console.ReadLine());

                        // auto generate room number = 1 is the less, 100 is the top (1-99)
                        Random random = new Random();
                        rommNum = random.Next(1, 100);

                        isGuestRegister = true;
                        Console.WriteLine("Guest Registered Successfully!");
                        break;


                    // View Guest Information
                    case 1:
                        if (isGuestRegister)
                        {
                          
                            Console.WriteLine("Guset Name: " + guestName.ToUpper());
                            Console.WriteLine("Guest Phone: " + gustPhone);
                            Console.WriteLine("Room Type: " + roomType);
                            Console.WriteLine("Nightly rate: " + Math.Round(nightlyRate).ToString()); // it is not work!!!
                            Console.WriteLine("Room number: " + nightlyRate.ToString());
                            
                        }

                        else
                        {
                            Console.WriteLine("No guset registerd..");
                        }
                        
                        break;

                    // Check-In Guest
                    case 2:
                        if(isGuestRegister) {
                        Console.Write("Enter number of nights: ");
                        numOfNights = Convert.ToInt32(Console.ReadLine());

                        // check-in date from system clock.
                        checkIndate = DateTime.Now;

                        // date and time today 
                        checkIndate = DateTime.Today;

                        //Compute and store check out date based on number of nights
                          checkOutdate= checkIndate.AddDays(numOfNights);
                        string formattedDate = checkOutdate.ToString("yyyy-MM-dd HH:mm:ss");

                            isCheckIn = true;

                            Console.WriteLine("Guest check in successfuly..");
                            Console.WriteLine("Check-In Date: " + checkIndate);
                            Console.WriteLine("Check-Out Date: " + checkOutdate);
                        }
                        else
                        {
                            Console.WriteLine("No guest registered.");
                        }

                        break;







                }

            }

        }
    }
}
