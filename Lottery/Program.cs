using System;
using System.Collections.Generic;
using System.Linq;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            string user_name;

            //Welcome!

            Console.WriteLine("Welcome to Lottery!");
            Console.Write("Please enter your name: ");

            user_name = Console.ReadLine();

            Console.WriteLine();
            Console.Write($"Hello {user_name}!");

            //Can you play?

            Console.Write("\n\nEnter your age: ");
            int user_age = 0;

            while (user_age == 0)
            {
                try
                {
                    user_age = Int32.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {

                    //Console.WriteLine(e.ToString());
                    Console.Write("\nYour age is a number, try again: ");

                }
            }
                
            //User list

            List<int> numList = new List<int>();


            if (user_age < 18)
            {
                Console.Write("\nSorry, you cannot play yet.");
            }
            else
            {
                Console.Write("OK.\n");

            START:  numList.Clear();
                
                Console.Write("\nEnter numbers from 1 to 36.\n");
               
                while (numList.Count < 7)
                {
                    Console.Write("\n   Add a number: ");
                    
                    try
                    {
                        int num = Int32.Parse(Console.ReadLine());

                        if (num < 37 && num > 0)
                        {
                            bool exists = numList.Contains(num);
                            if (exists == false)
                            {
                                numList.Add(num);
                                continue;
                            }
                            else if (exists == true)
                            {
                                Console.Write("\nThe number already exists!\n");
                            }
                        }
                        else
                        {
                            Console.Write("\nTry again!\n");
                        }
                    }
                    catch
                    {
                        Console.Write("\nTry again!\n");
                    }
                    
                }

                int list_size = numList.Count();

                Console.Write("\nYou have chosen:\n[");
                for (int i = 0; i < list_size; i++)
                {
                    if (i < list_size - 1)
                    {
                        Console.Write(numList[i] + ", ");
                    }
                    else
                    {
                        Console.Write(numList[i] + "]");
                    }
                }

                //Computer list

                List<int> numList_2 = new List<int>();

                while (numList_2.Count < 7)
                {
                    Random random = new Random();

                    int num_2 = random.Next(1, 37);
                    
                    bool exists_2 = numList_2.Contains(num_2);

                    if (exists_2 == false)
                    {
                        numList_2.Add(num_2);
                        continue;
                    }
                    else if (exists_2 == true)
                    {
                        continue;
                    }
                    
                }
                
                int list_2_size = numList_2.Count();

                Console.Write("\n\nComputer has chosen:\n[");
                for (int i = 0; i < list_2_size; i++)
                {
                    if (i < list_2_size - 1)
                    {
                        Console.Write(numList_2[i] + ", ");
                    }
                    else
                    {
                        Console.Write(numList_2[i] + "]");
                    }
                }
                
                int counter = 0;
                for (int i = 0; i < list_size; i++)
                {
                    for (int j = 0; j < list_2_size; j++)
                    {
                        if (numList[i] == numList_2[j])
                        {
                            counter++;
                            break;
                        }
                    }

                }

                if (counter == 1)
                {
                    Console.Write($"\n\nThere is 1 matching number!");
                }
                else
                {
                    Console.Write($"\n\nThere are {counter} matching numbers!");
                }
                 
                Console.Write("\n\n\n\n");
                goto START;
            }

            Console.ReadLine();
        }
    }
}
