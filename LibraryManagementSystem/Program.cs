using static System.Net.WebRequestMethods;

namespace LibraryManagementSystem
{
    internal class Program
    {
        //--for understand--
        //user defind function part
        //method head
        //method body
        //void >> no return value (e.x console.clear())


        //rejon 1 : system storage ( variables )
        // variables
        //member -- global variables , every function can access
        static string MemberName = "";
        static string MemberId = "";
        static string MemberEmail = "";
        static string MemberShipExirDate = "";
        static string MemberTire = "";
        static bool MemberIsRegister = false;

        //book
        static string BookTitle = "";
        static string BookAuthor = "";
        static string BookGenre = "";
        static int numOfCopies = 0;
        static int totBookBorrow = 0;
        static double totFinesPaid = 0;
        static bool BookIsRegister = false;


        //case 0 -- register function
        static void RegisterMember() {
            if (MemberIsRegister) {
                Console.WriteLine("Member is already Register..");
                return;
            }
            Console.WriteLine("Enter Member Name: ");
            MemberName = Console.ReadLine();
           
            Console.WriteLine("Enter Email: ");
            MemberEmail = Console.ReadLine();

            Console.WriteLine("Enter Member Tire: ");
            MemberTire = Console.ReadLine();

            MemberShipExirDate = DateTime.Now.ToString("yyy-MM-dd");
            string nameOfMember = MemberName.Substring(0,5);

            MemberIsRegister = true;

            Console.WriteLine("Member Registered Successfully.");
        }
        

        // case 1 -- display member profile ()
        static void displayMemberProfile()
        {
            Console.WriteLine(" Member Profile ");
            Console.WriteLine("Member Name: " + MemberName.PadLeft(10));
            Console.WriteLine("Member Email: " + MemberEmail);
            Console.WriteLine("Member id: " + MemberId.ToString());
            Console.WriteLine("Member Expiry Date: " + MemberShipExirDate);
            Console.WriteLine("Member tire: " + MemberTire);
        }


        // case 2 -- search book by title(return value function)
        static bool SearchBook(string key)
        {
            //convert string to lowercase
            string title = BookTitle.ToLower();
            key = key.ToLower();

            // check if keyword insid title 
            if (title.Contains(key))
            {
                return true;
            }

            return false;
        }

        // case 3 -- Borrow book
        static void borrowBook(ref int copies)
        {
            copies = Math.Max(0, copies);

            Console.WriteLine("book borrowed successfuly.");
            Console.WriteLine("Available copies: " + copies);

            if (!BookIsRegister)
            {
                Console.WriteLine("No book registered.");
               
            }

            borrowBook(ref numOfCopies);
        }


        // case 8 -- register book (optinal parameter , the default is general)
         static void ReggisterBook(string genre = "General") 
        {
            Console.WriteLine("Enter book title: ");
            BookTitle = Console.ReadLine().Trim();

            Console.WriteLine("Enter author name: ");
            BookAuthor = Console.ReadLine();

            Console.WriteLine("Enter the number of copies: ");
            // parse => because readline always read string
            numOfCopies = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter genre: ");
            string inputgenre = Console.ReadLine();

            BookIsRegister = true;


            Console.WriteLine("Book Registered Successfully.");
        }

        // case 10 -- Display book details
        static void displaybook(string title, string author, int copies, string genre)
        {
            Console.WriteLine(" Book details ");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " +  author);
            Console.WriteLine("Copies: " +  copies);
            Console.WriteLine("Genre: " +  genre);
        }















        // Main Menu Function
        public static void PrintMenu()
            {
                Console.WriteLine(" LIBRARY MANAGEMENT SYSTEM ");
                Console.WriteLine("0. Register Member");
                Console.WriteLine("1. display Member Profile");
                Console.WriteLine("2. search book by title");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Calculate Late Fine");
                Console.WriteLine("6. Apply Member Discount");
                Console.WriteLine("7. Check Borrowing Eligibility");
                Console.WriteLine("8. Register Book");
                Console.WriteLine("9. Generate Member ID");
                Console.WriteLine("10. Display Book Details");
                Console.WriteLine("11. Calculate Renewal Fee");
                Console.WriteLine("12. Update Member Email");
                Console.WriteLine("13. Session Summary");
                Console.WriteLine("14. Exit");
            }



        static void Main(string[] args)
        {
            //PrintMenu();

            bool exit = false;
            while (exit == false)
            {
                PrintMenu();

                Console.WriteLine("select an option from the menu:");
                int option = int.Parse(Console.ReadLine());
                

                switch (option)
                {

                    
                    case 0:
                        RegisterMember();
                        break;

                    
                    case 1:
                        displayMemberProfile();
                        break;

                   
                    case 2:
                       if (BookIsRegister == false)
                        {
                            Console.WriteLine("no book registerd yet.");
                            break;
                        }
                        Console.WriteLine("Enter keyword to search: ");
                        string key = Console.ReadLine();

                        if (SearchBook(key))
                        {
                            Console.WriteLine("Book found: " + BookTitle);
                        }
                        else
                        {
                            Console.WriteLine("no book found..");
                        }
                        break;

                    
                    case 3:
                        borrowBook(ref numOfCopies);
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
                        ReggisterBook();
                        break;

                    case 9:
                        break;

                    case 10:
                        displaybook(title: BookTitle,
                            author: BookAuthor,
                            copies: numOfCopies,
                            genre: BookGenre);
                        break;

                    case 11:
                        break;

                    case 12:
                        break;

                    case 13:
                        break;


                    case 14:
                        Console.WriteLine("Back to Main Menu");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("press any key to continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
