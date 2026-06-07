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

        //case 2 -- Queue -- 
        //Hotel Check-In Queue
        public static void hotelcheckin() { 
        
            //1
            Queue<string> gusetName = new Queue<string>();
            gusetName.Enqueue("Noor");
            gusetName.Enqueue("Reem");
            gusetName.Enqueue("Deemah");
            gusetName.Enqueue("Ruba");
            gusetName.Enqueue("Habiba");

            //2
            foreach (string name in gusetName) { 
            Console.WriteLine($"{name}");
            }

            //3
            Console.WriteLine("display who is next");
            Console.WriteLine(gusetName.Peek());

            //4 
            Console.WriteLine("first remove");
            string dequeue1 = gusetName.Dequeue();
            Console.WriteLine(dequeue1);

            Console.WriteLine("second remove");
            string dequeue2 = gusetName.Dequeue();
            Console.WriteLine(dequeue2);

            //5
            Console.WriteLine("Display the remaining queue after serving");
            foreach (string name in gusetName) {
                Console.WriteLine(name);
            }

            //6
            Console.WriteLine("Check whether reem still waiting and print the result");
            bool checkname = gusetName.Contains("Reem");
            if(checkname == false)
            {
                Console.WriteLine("Reem is not there..");
            }
            else
            {
                Console.WriteLine("Reem is still waiting");
            }

            //7
            Console.WriteLine(gusetName.Count() + " total number of gustse still in the list");


        }


        //case 3 -- stack -- 
        //Text Editor Undo System
        public static void TextEditiorsys()
        {
            //1
            Stack<string> undoStack = new Stack<string>();
            undoStack.Push("type noor");
            undoStack.Push("put space");
            undoStack.Push("type said");
            undoStack.Push("type humaid");
            undoStack.Push("copy noor said");
            undoStack.Push("paste noor said");
            undoStack.Push("delete humaid");

            //2
            foreach (string type in undoStack) {
                Console.WriteLine($"{type}");
            }

            //3
            Console.WriteLine("show which action would be undone next.");
            Console.WriteLine(undoStack.Peek());

            //4
            Console.WriteLine("Undo the last 2 actions");
            Console.WriteLine("First Undo");
            string fundo = undoStack.Pop();
            Console.WriteLine(fundo);

            Console.WriteLine("second Undo");
            string sundo = undoStack.Pop();
            Console.WriteLine(sundo);

            //5
            Console.WriteLine("Display the remaining undo history.");
            foreach (string type in undoStack) { 
            Console.WriteLine(type);
            }

            //6
            // crate a new stack to save the item 
            Stack<string> tempStack = new Stack<string>();
            while (undoStack.Peek() != "type humaid")
            {
                tempStack.Push(undoStack.Pop());
            }
            // check 
            undoStack.Peek();

            //now pop "type humaid"
            undoStack.Pop();

            // return the removable item from tempstack by pop the "copy noor" and push it in undstack
            while (tempStack.Count > 0)   
            {
                undoStack.Push(tempStack.Pop());
            }

            //7
            Console.WriteLine("Display the final Count of remaining actions.");
            foreach (string type in undoStack)
            {
                Console.WriteLine(type);
            }
        }


        //case 4 -- QUEUE -- 
        //Hospital Emergency Room Triage 
        public static void HospitalEmergency() { 
            //1
        Queue<string> triageQueue = new Queue<string>();
            triageQueue.Enqueue("asila");
            triageQueue.Enqueue("noor");
            triageQueue.Enqueue("sara");
            triageQueue.Enqueue("rahaf");
            triageQueue.Enqueue("hafsa");
            triageQueue.Enqueue("wjdan");
            triageQueue.Enqueue("hidaya");
            triageQueue.Enqueue("salwa");

            //2
            foreach (string pname in triageQueue)
            {
                Console.WriteLine($"{pname}");
            }

            //3
            Console.WriteLine("show who will be seen next");
            Console.WriteLine(triageQueue.Peek());

            //4
            Console.WriteLine("Process (dequeue) the first 3 patients");
            Console.WriteLine("First dequeue patients");
            string fdeq = triageQueue.Dequeue();
            Console.WriteLine(fdeq);

            Console.WriteLine("second dequeue patients");
            string sdeq = triageQueue.Dequeue();
            Console.WriteLine(sdeq);

            Console.WriteLine("Third dequeue patients");
            string tdeq = triageQueue.Dequeue();
            Console.WriteLine(tdeq);

            //5
            Console.WriteLine("Display the remaining queue.");
            foreach(string pname in triageQueue)
            {
                Console.WriteLine(pname); 
            }

            //6
            Console.WriteLine("remove wjdan");
            Queue<string> tempQueue = new Queue<string>();

            string removpatient = "wjdan";
            while (triageQueue.Count > 0)
            {
                string patient = triageQueue.Dequeue();
                if (patient != removpatient)
                {
                    tempQueue.Enqueue(patient);
                }
            }
                while (tempQueue.Count > 0)
                {
                    triageQueue.Enqueue(tempQueue.Dequeue());

                }
            

                //7
                Console.WriteLine("Remaining patient");
                foreach (string pname in triageQueue)
                {
                    Console.WriteLine($"{pname}");
                }

                Console.WriteLine("total patient remaining: " +  triageQueue.Count);

        }

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
                        hotelcheckin();
                        break;

                    case 3:
                        TextEditiorsys();
                        
                        break;

                    case 4:
                        HospitalEmergency();
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
