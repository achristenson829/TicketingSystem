using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace TicketingSystem
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            var option ="";
            do
            {
                Console.WriteLine("1. Read file");
                Console.WriteLine("2. Write File");
                Console.WriteLine("3. Exit");
                option = Console.ReadLine();
                if (option == "1")
                {
                    ReadFile();
                }
                else if (option == "2")
                {
                    WriteFile(); 
                }
                else
                {
                    Console.WriteLine("GoodBye!");
                }
            } while (option!="3");
            
        }

        static void ReadFile()
        {
            string file = "ticket.csv";
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
                sr.Close();
            }
            else
            {
                Console.WriteLine("File not found");
            }
            
        }

        static void WriteFile()
        {
            string file = "ticket.csv";
            StreamWriter sw = new StreamWriter(file, true);
            string resp = "";
            do
            {
                Console.WriteLine("Do you want to create a new ticket (Y/N)?");
                resp = Console.ReadLine().ToUpper();
                if (resp != "Y")
                {
                    break;
                }

                Console.WriteLine("Enter the ticket number");
                string num = Console.ReadLine();

                Console.WriteLine("Enter ticket summary");
                string summary = Console.ReadLine();

                Console.WriteLine("Enter Status");
                string status = Console.ReadLine();

                Console.WriteLine("Enter priority");
                string priority = Console.ReadLine();

                Console.WriteLine("Enter ticket submitter");
                string submitter = Console.ReadLine();

                Console.WriteLine("Enter person assigned to ticket");
                string assigned = Console.ReadLine();

                var choice = "";
                var names = new List<string>();
                do
                {
                    Console.WriteLine("Enter person watching ticket");
                    names.Add(Console.ReadLine());
                    Console.WriteLine("Is another person watching this ticket? Y/N "); 
                    choice = Console.ReadLine().ToUpper();
                } while (choice != "N");
                string watching = string.Join("|", names);
                
                sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", num, summary, status, priority, submitter, assigned,
                    watching);
            } while (resp != "N");

            sw.Close();
        }
    }
}