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

          

            bool exit = false;
            while (exit == false)
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

                
                int choice = int.Parse(Console.ReadLine());
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

                        Console.Write("Enter Room Notes: ");
                        roomNotes = Console.ReadLine();

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
                            Console.WriteLine("Room number: " + rommNum);
                            Console.WriteLine("Room Notes: " + roomNotes);

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


                    // Check - Out & Bill
                    case 3:
                        if (isCheckIn)
                        {
                            // calculate tot bill
                            double totBill = nightlyRate * numOfNights;

                            // discount
                            double totdiscount = totBill * (discountPersntage / 100);
                            double totamount = totBill - totdiscount;

                            // round the final amount
                            totamount = Math.Round(totamount);

                            //print bill
                            Console.WriteLine("Guset Name: " + guestName);
                            Console.WriteLine("Guest Phone: " + gustPhone);
                            Console.WriteLine("Room Type: " + roomType);
                            Console.WriteLine("Room number: " + rommNum );
                            Console.WriteLine("number of Nights: " + numOfNights);
                            Console.WriteLine("Nightly Rate: " + nightlyRate);
                            Console.WriteLine("discount Presentage: " + discountPersntage + "%");
                            Console.WriteLine("Total Amount: " + totamount);

                            // Reset the room after printing
                            guestName = "";
                            gustPhone = "";
                            roomType = "";
                            nightlyRate = 0;
                            rommNum = 0;
                            numOfNights = 0;
                            roomNotes = "";
                            discountPersntage = 0;

                            isGuestRegister = false;
                            isCheckIn = false;

                            Console.WriteLine("checked out sucessufly..");
                        }
                        else
                        {
                            Console.WriteLine("no guest check in");
                        }
                        break;


                    // Apply Discount
                    case 4:
                        if (isCheckIn)
                        {
                            double orginalAmount = numOfNights * nightlyRate;

                            // enter discount persentage
                            Console.Write("Enter discount percentage: ");
                            discountPersntage = Convert.ToDouble(Console.ReadLine());

                            double discount = orginalAmount * (discountPersntage / 100);
                            double totalAmount = orginalAmount - discount;

                            // round
                            orginalAmount = Math.Round(orginalAmount);
                            totalAmount = Math.Round(totalAmount);
                            discount = Math.Round(discount);

                            // to avoid the negetaive number
                            totalAmount = Math.Abs(totalAmount);


                            // orginal amount = 50 * 4 = 200
                            // discount = 200 * (10/100) = 20
                            // total amount = 200 - 20 = 180

                            //print
                            Console.WriteLine("Original Amount: " + orginalAmount);
                            Console.WriteLine("Discount Percentage: " + discountPersntage + "%");
                            Console.WriteLine("Total Amount: " + totalAmount);
                            Console.WriteLine("Discounted Amount: " + discount);
                        }
                        else
                        {
                            Console.WriteLine("Guest must check in first.");
                        }
                        break;


                    /////// i dont understand it
                    // Upgrade Room
                    case 5:
                        if (isGuestRegister)
                        {
                            double oldrate = nightlyRate;
                           
                            // enter new room info
                            Console.WriteLine("Enter new room type: ");
                            roomType = Console.ReadLine();

                            Console.WriteLine("Enter new nightly rate: ");
                            nightlyRate = Convert.ToDouble(Console.ReadLine());

                            // high Top rate
                            double TopRate = Math.Max(oldrate, nightlyRate);

                            //less rate
                            double lessRate = Math.Min(oldrate, nightlyRate);

                            //different between 2 rate
                            double diffrent = Math.Abs(nightlyRate - oldrate);

                            //print
                            Console.WriteLine("Old Rate: " + oldrate);

                            Console.WriteLine("New Room Type: " + roomType);
                            Console.WriteLine("New Rate: " + nightlyRate);
                            Console.WriteLine("max Rate: " + TopRate);
                            Console.WriteLine("Less Rate: " + lessRate);
                            Console.WriteLine("The Difference: " + diffrent);
                            Console.WriteLine("Room upgraded successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No guest registered.");
                        }
                        break;



                    // Add Room Service Note
                    case 6:
                        if (isGuestRegister)
                        {
                            Console.Write("Enter room service note: ");
                            string newNotes = Console.ReadLine();
                            newNotes = newNotes.Trim();
                           

                            if (newNotes.Length != 0)
                            {
                                
                                //reblace also to ,
                                roomNotes = roomNotes.Replace("also", ",");
                                newNotes = newNotes.Replace("also", ",");
                                // add the new notes
                                Console.WriteLine(roomNotes + " | " + newNotes);

                                string newComment = roomNotes + newNotes;
                                //print
                                Console.WriteLine("Room Notes: " + newComment);
                                Console.WriteLine("Notes Lenght: " + roomNotes.Length);
                            }
                            else
                            {
                                Console.WriteLine(" the note can not be blank");
                            }
                        }
                        else
                        {
                            Console.WriteLine("there is no guesr register!");
                        }
                        break;


                    // Search Guest by Name
                    case 7:
                        if (isGuestRegister)
                        {
                            Console.Write("Type the Name to find the Guest: ");
                            string Key = Console.ReadLine();
                            Key = Key.ToLower();
                            string lowerguest = guestName.ToLower();

                            if (lowerguest.Contains(Key))
                            {
                                Console.WriteLine("Guest Name: " + guestName);
                            }
                            else
                            {
                                Console.WriteLine("Guest not Found..");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Guest not Registerd!");
                        }
                        break;



                    // Calculate Loyalty Points
                    case 8:
                        if (isGuestRegister)
                        {
                            double firstpoint = Math.Pow(numOfNights, 2);
                            firstpoint = Math.Round(firstpoint);



                        }
                        break;


                    // Print Receipt
                    case 9:

                        break;


                    // Edit Guest Name
                    case 10:

                        break;



                    case 11: // exit
                        exit = true;
                        break;

                    default:// invalid option
                        Console.WriteLine("invalid option please try again");
                        break;


                }

            }

            Console.WriteLine("press any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
