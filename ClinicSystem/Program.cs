using Microsoft.VisualBasic;
using System.Xml.Linq;

namespace ClinicSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //region 1 system storage (variables)
            // store patient information
            String patientName = "";
            int patientAge = 0;
            string patientPhone = "";
            int patientCount = 0;
            bool isActive = false;
            string patientId = "";
            //int MAX_PATIENT = 3;


            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("0. Add Patient Information");
                Console.WriteLine("1. View Patient Information");
                Console.WriteLine("2. Edit Patient Information");
                Console.WriteLine("3. delete Patient");
                Console.WriteLine("4. Exit");

                Console.WriteLine("please select an option from the menu:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {

                    //add patient
                    case 0:
                        Console.Write("Add New Patient");

                        //check clinic full
                        if (isActive == true)
                        {
                            Console.WriteLine("Clinic is full. Cannot add more patients.");
                            break;
                        }

                        //add id
                        Console.Write("Enter Patient ID: ");
                        string id = Console.ReadLine();

                        // add patient name
                        Console.Write("Enter patient name: ");
                        string name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.WriteLine("Invalid name.");
                            break;
                        }

                        //add age
                        Console.Write("Enter age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        if (age < 1 || age > 100)
                        {
                            Console.WriteLine("error");
                            break;
                        }

                        //add phone
                        Console.Write("Enter phone number: ");
                        string phone = Console.ReadLine();


                        // read free slot
                        if (isActive == false)
                        {
                            patientId = id;
                            patientName = name;
                            patientAge = age;
                            patientPhone = phone;
                            isActive = true;
                        }
                        patientCount++;
                        Console.WriteLine("Patient added successfully");
                        break;


                    // View Patient Information
                    case 1:
                        Console.WriteLine("View All Patients");

                        // check if there is patient
                        if (patientCount == 0)
                        {
                            Console.WriteLine("No patients registered.");
                            break;
                        }

                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("1. View All Patient Information");
                        Console.WriteLine("2. View One Patient Only");

                        int choice = int.Parse(Console.ReadLine());
                        //check each slot
                        if (choice == 1)
                        {
                            // view all patient information
                            Console.WriteLine("patient Information:");
                            Console.WriteLine("patient name: " + patientName);
                            Console.WriteLine("patient age: " + patientAge);
                            Console.WriteLine("patient phone: " + patientPhone);
                        }
                        // view patient using id
                        else if (choice == 2)
                            {
                                Console.WriteLine("Enter Patient ID:");
                                int searchid = int.Parse(Console.ReadLine());

                                // Check if ID exists
                                if (searchid == 1 && isActive == true)
                                {
                                    Console.WriteLine("Patient Information:");
                                    Console.WriteLine("Patient ID: " + patientId);
                                    Console.WriteLine("Patient Name: " + patientName);
                                    Console.WriteLine("Patient Age: " + patientAge);
                                    Console.WriteLine("Patient Phone: " + patientPhone);
                                }
                                else
                                {
                                    Console.WriteLine("Patient not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid.");
                            } 

                        break;


                    //Edit Patient Information
                    case 2:
                        Console.WriteLine("Update Patient Phone");
                        // read patient name
                        Console.Write("Enter patient name: ");
                        string searchName = Console.ReadLine();

                        // check patinet
                        if (isActive && patientName == searchName)
                        {
                            Console.Write("Enter new phone: ");
                            string newPhone = Console.ReadLine();
                            patientPhone = newPhone;
                            Console.WriteLine("Updated Successefully");
                        }
                        else
                        {
                            Console.WriteLine("Patient not found!");
                        }

                        break;


                    //delete Patient
                    case 3:
                        Console.WriteLine("Delete Patient");

                        //read patient name
                        Console.Write("Enter patient name: ");
                        string deleteName = Console.ReadLine();

                        //check patient
                        if (isActive && patientName == deleteName)
                        {
                            isActive = false;
                            patientId = "";
                            patientName = "";
                            patientAge = 0;
                            patientPhone = "";
                            patientCount--;
                            Console.WriteLine("Patient deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Patient not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Back to Main Menu");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

            Console.WriteLine("press any key to continu..");
            Console.ReadKey();
            Console.Clear();

        }
    }
        }
    