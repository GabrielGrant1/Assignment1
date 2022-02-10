using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int ID = 0;
            string file = "Files/tickets.csv";
            string file2 = "Files/tickets.txt";
            bool close = false;
            var menuSelection = "";

            do
            {
                menuSelection = MenuPrompt();
                if (menuSelection == "1")
                {
                    if (File.Exists(file2))
                    {
                        StreamReader sr = new StreamReader(file2);
                        int count = 0;
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] column = line.Split(',');
                            if (count >= 1) //skips printing header.
                            {
                                Console.WriteLine(
                                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                    column[0], column[1], column[2], column[3], column[4], column[5], column[6]);
                            }
                            count++;
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist.");
                    }

                }
                else if (menuSelection == "2")
                {
                    ID++;
                    int count = 0;
                    int i = 0;
                    string[] newEntry = new string[7];
                    ArrayList watchList = new ArrayList();
                    string person = "";
                    StreamWriter sw = new StreamWriter(file2, true); // Had issues with csv file formatting, used txt format.


                    string ticketID = Convert.ToString(ID);
                    Console.WriteLine("Enter summary");
                    string summary = (Console.ReadLine());
                    Console.WriteLine("Status?");
                    string status = Console.ReadLine();
                    Console.WriteLine("Priority?");
                    string priority = Console.ReadLine();
                    Console.WriteLine("Enter you name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Assigned?");
                    string assigned = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Enter watching person? (Press E to exit)");
                        person = Console.ReadLine();
                        if (person.ToUpper() != "e")
                        {
                            watchList.Add(person);
                            count++;
                        }
                    } while (person.ToUpper() != "E");

                    string[] w = new string[count];
                    foreach (string p in watchList)
                    {
                        w[i] = p;
                        i++;
                    }
                    string watching = string.Join('|', w);

                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", 
                        ticketID, summary, status, priority, name, assigned, watching);
                    sw.Close();
                    Console.Clear();
                }
                else
                {
                    close = true;
                }
            } while (close == false);
        }

        private static string MenuPrompt()
        {
            string m;
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create file from data.");
            Console.WriteLine("3) Exit");
            m = Console.ReadLine();
            return m;
        }
    }
}