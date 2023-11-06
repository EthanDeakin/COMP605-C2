using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Diagnostics;
using System.Linq.Expressions;

namespace COMP605_C2
{
    internal class Program
    {
        private static DBLList myList = new DBLList();
        private static bool run = true;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("***Reading Txt Files***");
                while (run) {
                    MenuUI();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to close the program...");
            Console.ReadKey();

        }

        // UI
        static void MenuUI()
        {
            int opt = 0; // initialise menu option
            while (opt < 1 || opt > 6)
            {   // valid option not selected
                Console.Clear();
                Console.WriteLine("***** Welcome to the Double Linked List App *****");
                Console.WriteLine("");
                Console.WriteLine("1 - Load file");
                Console.WriteLine("2 - Insert");
                Console.WriteLine("3 - Delete");
                Console.WriteLine("4 - Search");
                Console.WriteLine("5 - Print");
                Console.WriteLine("6 - Exit");
                Console.WriteLine("");
                Console.WriteLine("Enter option: ");

                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
                else if (int.TryParse(input, out opt) && opt >= 1 && opt <= 6)
                {
                    MenuOpts(opt);
                }
                else
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
            }
        }

        static void MenuOpts(int opt)
        {
            switch (opt)
            {
                case 1:
                    ChooseFile();
                    break;
                case 2:
                    InsertOpts();
                    break;
                case 3:
                    DeleteOpts();
                    break;
                case 4:
                    FindOpts();
                    break;
                case 5:
                    Print();
                    break;
                case 6:
                    Quit();
                    break;
                default:
                    // Invalid menu option
                    Console.WriteLine("Invalid menu option");
                    break;
            }
        }

        private static void ChooseFile()
        {
            int opt = 0;
            while (opt < 1 || opt > 12)
            {   // valid option not selected
                Console.Clear();
                Console.WriteLine("***** Load file from the directory *****");
                Console.WriteLine("");
                Console.WriteLine("1 - 1000 Words");
                Console.WriteLine("2 - 5000 Words");
                Console.WriteLine("3 - 10000 Words");
                Console.WriteLine("4 - 15000 Words");
                Console.WriteLine("5 - 20000 Words");
                Console.WriteLine("6 - 25000 Words");
                Console.WriteLine("7 - 30000 Words");
                Console.WriteLine("8 - 35000 Words");
                Console.WriteLine("9 - 40000 Words");
                Console.WriteLine("10 - 450000 Words");
                Console.WriteLine("11 - 50000 Words");
                Console.WriteLine("12 - Return to Main Menu");
                Console.WriteLine("");
                Console.WriteLine("Enter option: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
                else if (int.TryParse(input, out opt) && opt >= 1 && opt <= 12)
                {
                    FileOpts(opt);
                }
                else
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
            }
        }

        static void FileOpts(int opt)
        {
            switch (opt)
            {
                case 1:
                    ReadFile(@"../../TempFiles/1000-words.txt");
                    break;
                case 2:
                    ReadFile(@"../../TempFiles/5000-words.txt");
                    break;
                case 3:
                    ReadFile(@"../../TempFiles/10000-words.txt");
                    break;
                case 4:
                    ReadFile(@"../../TempFiles/15000-words.txt");
                    break;
                case 5:
                    ReadFile(@"../../TempFiles/20000-words.txt");
                    break;
                case 6:
                    ReadFile(@"../../TempFiles/25000-words.txt");
                    break;
                case 7:
                    ReadFile(@"../../TempFiles/30000-words.txt");
                    break;
                case 8:
                    ReadFile(@"../../TempFiles/35000-words.txt");
                    break;
                case 9:
                    ReadFile(@"../../TempFiles/40000-words.txt");
                    break;
                case 10:
                    ReadFile(@"../../TempFiles/45000-words.txt");
                    break;
                case 11:
                    ReadFile(@"../../TempFiles/50000-words.txt");
                    break;
                case 12:
                    break;
                default:
                    // Invalid menu option
                    Console.WriteLine("Invalid menu option");
                    break;
            }
        }

        static void ReadFile(string pathName)
        {
            try
            {
                myList = new DBLList(); // Clears the dictionary before making a new one
                string[] lines = File.ReadAllLines(pathName);
                int count = 0;
                HashSet<string> check = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (string line in lines)
                {
                    string lineToAdd = line.Trim(); // Remove leading/trailing whitespace

                    // Check if the word is unique (case insensitive)
                    if (check.Add(lineToAdd))
                    {
                        AddToEnd(lineToAdd);
                        Console.WriteLine("Node " + count++ + " -> " + lineToAdd);
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.WriteLine("*** File loaded successfully ***");
                Console.WriteLine("*** " + count++ + " words loaded successfully ***");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("--- An error occured loading the file ---");
                Console.WriteLine(e);
            }
        }

        public static void InsertOpts()
        {
            int opt = 0;
            while (opt < 1 || opt > 5)
            {   // valid option not selected
                Console.Clear();
                Console.WriteLine("*** Choose insert method ***");
                Console.WriteLine("");
                Console.WriteLine("1 - Insert to front");
                Console.WriteLine("2 - Insert to back");
                Console.WriteLine("3 - Insert before a word");
                Console.WriteLine("4 - Insert after a word");
                Console.WriteLine("5 - Return to Main Menu");
                Console.WriteLine("");
                Console.WriteLine("Enter option: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
                else if (int.TryParse(input, out opt) && opt >= 1 && opt <= 5)
                {
                    InsertOpts(opt);
                }
                else
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
            }
        }

        static void InsertOpts(int opt)
        {
            switch (opt)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Enter a word to add to the front: ");
                    string input1 = Console.ReadLine();
                    AddToFront(input1);
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Enter a word to add to the rear: ");
                    string input2 = Console.ReadLine();
                    //Time Complexity
                    Stopwatch sw = Stopwatch.StartNew();
                    sw.Start();
                    AddToEnd(input2);
                    sw.Stop(); // Stop time

                    // Extract time from stopwatch
                    TimeSpan timespan = sw.Elapsed;

                    // Output time taken as seconds
                    Console.WriteLine("*** Time taken to perform insert ***");
                    Console.WriteLine("Time: " + timespan.ToString(@"ss\.fffffff") + " {s}");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    if (myList.Head == null)
                    {
                        Console.WriteLine("List is empty");
                    }
                    else
                    {
                        Console.WriteLine("Enter a word you would like to insert: ");
                        input1 = Console.ReadLine();
                        Console.WriteLine("Enter a word you would like to insert before: ");
                        input2 = Console.ReadLine();
                        AddBefore(input1, input2);
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    if (myList.Head == null)
                    {
                        Console.WriteLine("List is empty");
                    }
                    else
                    {
                        Console.WriteLine("Enter a word you would like to insert: ");
                        input1 = Console.ReadLine();
                        Console.WriteLine("Enter a word you would like to insert after: ");
                        input2 = Console.ReadLine();

                        //Time Complexity
                        sw = Stopwatch.StartNew();
                        sw.Start();
                        AddAfter(input1, input2);
                        sw.Stop(); // Stop time

                        // Extract time from stopwatch
                        timespan = sw.Elapsed;

                        // Output time taken as seconds
                        Console.WriteLine("*** Time taken to perform insert ***");
                        Console.WriteLine("Time: " + timespan.ToString(@"ss\.fffffff") + " {s}");
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    break;
                default:
                    // Invalid menu option
                    Console.WriteLine("Invalid menu option");
                    break;
            }
        }

        public static void AddToFront(string word)
        {   // UI Merthod call
            Node temp = new Node(word);
            myList.InsertAtFront(temp);
        }

        public static void AddToEnd(string word)
        {   // UI Merthod call
            Node temp = new Node(word);
            myList.InsertAtRear(temp);
        }

        public static string AddBefore(string word, string target)
        {
            Node newNode = new Node(word);
            Node targetNode = new Node(target);
            try
            {
                if (myList.InsertBefore(newNode, targetNode))
                {
                    return "Target " + targetNode.ToPrint() + " found, NODE: " + newNode.ToPrint() + " inserted";
                }
                else
                {
                    return "Target " + targetNode.ToPrint() + " NOT found, NODE: " + newNode.ToPrint() + " NOT inserted";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"--- An error occurred while inserting before {word} ---");
                Console.WriteLine(e);
                return "";
            }
        }

        public static string AddAfter(string word, string target)
        {
            Node newNode = new Node(word);
            Node targetNode = new Node(target);
            try
            {
                if (myList.InsertAfter(newNode, targetNode))
                {
                    return "Target " + targetNode.ToPrint() + " found, NODE: " + newNode.ToPrint() + " inserted";
                }
                else
                {
                    return "Target " + targetNode.ToPrint() + " NOT found, NODE: " + newNode.ToPrint() + " NOT inserted";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"--- An error occurred while inserting after {word} ---");
                Console.WriteLine(e);
                return "";
            }
        }

        public static void FindOpts()
        {
            Console.Clear();
            if (myList.Head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                Console.WriteLine("*** Enter a word to search the list ***");
                Console.WriteLine("");
                Console.WriteLine("Search: ");
                string input1 = Console.ReadLine();
                Console.WriteLine(Find(input1));
            }
            Console.ReadKey();
        }

        public static string Find(string word)
        {
            int pos = 0;
            Node nodeToFind = new Node(word);
            pos = myList.Search(nodeToFind);
            if (pos >= 1 && pos <= myList.Counter)
            {
                return "Target: " + word.ToString() + ", NODE found at position: " + pos.ToString();
            }
            else
            {
                return "Target: " + word.ToString() + ", Node not found, OR list empty";
            }

        }

        public static void DeleteOpts()
        {
            int opt = 0;
            while (opt < 1 || opt > 2)
            {   // valid option not selected
                Console.Clear();
                Console.WriteLine("***** Are you sure you want to delete? *****");
                Console.WriteLine("");
                Console.WriteLine("1 - Delete a word");
                Console.WriteLine("2 - Return to Main Menu");
                Console.WriteLine("");
                Console.WriteLine("Enter option: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
                else if (int.TryParse(input, out opt) && opt >= 1 && opt <= 2)
                {
                    DeleteOpts(opt);
                }
                else
                {
                    Console.WriteLine("Invalid menu option");
                    Console.ReadKey();
                }
            }
        }

        public static void DeleteOpts(int opt)
        {
            Console.Clear();
            if (myList.Head == null)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                switch (opt)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter a word you would like to delete (this action cannot be undone): ");
                        string input1 = Console.ReadLine();
                        Delete(input1);
                        break;
                    case 2:
                        break;
                    default:
                        // Invalid menu option
                        Console.WriteLine("Invalid menu option");
                        break;
                }
            }
            Console.ReadKey();
        }

        private static void Delete(string word)
        {
            try
            {
                Node nodeToDelete = new Node(word);
                Console.WriteLine(nodeToDelete.ToString());
                Node deletedNode = myList.DeleteNode(nodeToDelete);

                Console.Clear();
                if (myList.Head == null)
                {
                    Console.WriteLine("List is empty");
                }
                else if (deletedNode != null)
                {
                    Console.WriteLine("Target: " + word.ToString() + ", NODE deleted");
                }
                else
                {
                    Console.WriteLine("Target: " + word.ToString() + ", Node not found, OR list empty");
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("--- An error occured deleting the node ---");
                Console.WriteLine(e);
            }
        }

        // ToPrint()
        private static void Print()
        {
            Console.Clear();
            myList.Counter = 0;
            Console.WriteLine(myList.PrintDictionaryOp());
            Console.ReadKey();
        }

        // Quit
        private static void Quit()
        {
            run = false;
        }
    }
}
