using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //lastname contains a set of last names
            string[] lastname = new string[10] { "Ivanov", "Petrova", "Sidorov", "Smirnova", "Fedorov", "Alekseeva", "Kovalev", "Mamontova", "Kiselev", "Trankova" };
            
            List < Human > humans= new List<Human>(); int k=1;

            //first initialization of human dynamic list by lastname, empty strings and default gender
            for (int i = 0; i < lastname.Length; i++)
            {
                humans.Add(new Human());
                humans[i].lastname =lastname[i];
                humans[i].firstname = "";
                humans[i].interest = "";
                if ((k % 2) == 0) humans[i].gender = Human._gender.female;
                else humans[i].gender = Human._gender.male;
                k++;
            }
            
            //res will contain action which user entered
            string res;
            
            do
            {
                Console.WriteLine("\nEnter action:\n- type \"Add\" to add new element;\n- type \"Set\" to change any elements parametr;\n- type \"Remove\" to delete element;\n- type \"sort Family\" to sort array by last name;\n- type \"sort Name\" to sort array by first name;\n- type \"print\" to see all elements;\n- type \"help\" to repeat list of available actions;\n- type \"exit\" to quit.\n");
                res = Console.ReadLine();
                switch (res)
                {
                    case "print":
                        {
                            Operations.Print(ref humans);
                            break;
                        }
                    case "sort Family":
                        {
                            Operations.SortFamily(ref humans);
                            break;
                        }
                    case "sort Name":
                        {
                            Operations.SortName(ref humans);
                            break;
                        }
                    case "Set":
                        {
                            Operations.Set(ref humans);
                            break;
                        }
                    case "Add":
                        {
                            Operations.Add(ref humans);
                            break;
                        }
                    case "Remove":
                        {
                            Operations.Remove(ref humans);
                            break;
                        }
                    case "help":
                        {
                            /*Console.WriteLine("\nEnter action:\n- type \"Add\" to add new element;\n- type \"Set\" to change any elements parametr;\n- type \"Remove\" to delete element;\n- type \"sort Family\" to sort array by last name;\n- type \"sort Name\" to sort array by first name;\n- type \"print\" to see all elements;\n- type \"help\" to repeat list of available actions;\n- type \"exit\" to quit.\n");*/
                            break;
                        }
                    case "exit":
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }

                }

            }
            while (!(res.Equals("exit"))); 
        }
    }

    //the main type of data
    class Human
    {
        public enum _gender { male, female };
        
        public string firstname;
        public string lastname;
        public string interest;
        public _gender gender;

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", firstname, lastname, interest, gender);
        }
    }

    //contains defferent methods 
    class Operations
    {
        //Add a new human in list
        public static void Add(ref List<Human> humans)
        {
            humans.Add(new Human());
            Console.Write("\nEnter first name: ");
            string name = Console.ReadLine();
            humans.Last().firstname = name;
            Console.Write("Enter last name: ");
            string lastname = Console.ReadLine();
            humans.Last().lastname = lastname;
            Console.Write("Enter interest: ");
            string interest = Console.ReadLine();
            humans.Last().interest = interest;
            Operations.ChangeGender(ref humans.Last().gender);

            Console.WriteLine("\nYou added new human: {0}", humans.Last());
        }

        //Remove human from list
        public static void Remove(ref List<Human> humans)
        {
            
            Console.WriteLine("\nChoose a number of element to remove:");
            for (int i = 0; i < humans.Count; i++ )
            {
                Console.WriteLine("{0} {1}", i, humans[i]);
            }
            int number;
            Console.WriteLine();
            string row = Console.ReadLine();
            try 
            {
                if (int.TryParse(row, out number))
                {
                     if ((number >= 0) && (number <= humans.Count-1))
                    {
                        humans.RemoveAt(number);
                        Console.WriteLine("Element was successufully  removed");
                    }
                    else
                    {
                        throw new OutOfRangeException();
                        //Console.WriteLine("\nNumber is out of range");
                    }
                }
                else
                {
                    throw new InvalidParametrException();
                    //Console.WriteLine("\nYou need to choise number");
                }
                
                
            }
            catch (OutOfRangeException ex)
            {
                Console.WriteLine("\nNumber is out of range");
            }
            catch (InvalidParametrException ex)
            {
                Console.WriteLine("\nYou need to choise number");
            }
            /*catch
            {
                Console.WriteLine("Error");
            }*/

        }

        //Change the value of any parametr
        public static void Set(ref List<Human> humans)
        {
            Console.WriteLine("\nChoose a number of element to set any option:");
            for (int i = 0; i < humans.Count; i++)
            {
                Console.WriteLine("{0} {1}", i, humans[i]);
            }
            int number;
            Console.WriteLine();
            string row = Console.ReadLine();
            try
            {
                if (int.TryParse(row, out number))
                {
                    if ((number >= 0) && (number <= humans.Count - 1))
                    {
                        Console.WriteLine("\nYou choise is \"{0}\"\n\nEnter \"1\" to change first name, \"2\" - to change last name, \"3\" - to change interest, \"4\" - to change gender\n", humans[number]);
                         int x;
                         string choise = Console.ReadLine();
                         if (int.TryParse(choise, out x))
                         {
                             switch (x)
                             {
                                 case 1:
                                    {
                                        Console.Write("\nEnter new first name: ");
                                        string name = Console.ReadLine();
                                        humans[number].firstname = name;
                                        Console.WriteLine("\nAfter changes {0} element of array is \"{1}\"", number, humans[number]);
                                        break;
                                    };
                                 case 2:
                                    {
                                        Console.Write("\nEnter new last name: ");
                                        string lastname_new = Console.ReadLine();
                                        humans[number].lastname = lastname_new;
                                        Console.WriteLine("\nAfter changes {0} element of array is \"{1}\"", number, humans[number]);
                                        break;
                                     };
                                 case 3:
                                      {
                                          Console.Write("\nEnter new interest: ");
                                          string interest = Console.ReadLine();
                                          humans[number].interest = interest;
                                          Console.WriteLine("\nAfter changes {0} element of array is \"{1}\"", number, humans[number]);
                                          break;
                                      }
                                 case 4:
                                      {
                                          Operations.ChangeGender(ref humans[number].gender);
                                          Console.WriteLine("\nAfter changes {0} element of array is \"{1}\"", number, humans[number]);
                                          break;
                                      }
                                 default:
                                      {
                                            Console.WriteLine("\nYou entered incorrect number");
                                            break;
                                       }
                             }
                        }
                        else
                        {
                             throw new InvalidParametrException();
                             //Console.WriteLine("\nYou need to choise number");
                        }
                        
                    }
                    else
                    {
                        throw new OutOfRangeException();
                        //Console.WriteLine("\nNumber is out of range");
                    }
                }
                else
                {
                    throw new InvalidParametrException();
                    //Console.WriteLine("\nYou need to choise number");
                }

            }
            catch (OutOfRangeException ex)
            {
                Console.WriteLine("\nNumber is out of range");
            }
            catch (InvalidParametrException ex)
            {
                Console.WriteLine("\nNumber is out of range");
            }

        }

        //print the list of humans
        public static void Print(ref List<Human> humans)
        {
            for (int i = 0; i < humans.Count; i++)
            {
                Console.WriteLine("{0}", humans[i]);
            }
        }

        //Sort by first names
        public static void SortName(ref List<Human> humans)
        {
            List<string> firstname = new List<string>();
            for (int i=0; i<humans.Count;i++)
            {
                firstname.Add(humans[i].firstname);
            }

            firstname.Sort();
            string temp0, temp1, temp2;
            Human._gender gender;
            for (int j = 0; j < firstname.Count; j++)
            {
                for (int i = 0; i < humans.Count; i++)
                {
                    if (humans[i].firstname.Equals(firstname[j]))
                    {
                        temp0 = humans[j].firstname;
                        temp1 = humans[j].lastname;
                        temp2 = humans[j].interest;
                        gender = humans[j].gender;
                        humans[j].firstname = humans[i].firstname;
                        humans[j].lastname = humans[i].lastname;
                        humans[j].interest = humans[i].interest;
                        humans[j].gender = humans[i].gender;
                        humans[i].firstname = temp0;
                        humans[i].lastname = temp1;
                        humans[i].interest = temp2;
                        humans[i].gender = gender;

                    }
                }
            }
            Console.WriteLine("Elements sorted by first names successufully");
        }

        //Sort by last names
        public static void SortFamily(ref List<Human> humans)
        {
            List<string> lastname = new List<string>();
            for (int i = 0; i < humans.Count; i++)
            {
                lastname.Add(humans[i].lastname);
            }
            lastname.Sort();
            string temp0, temp1, temp2;
            Human._gender gender;
            for (int j = 0; j < lastname.Count;j++)
            {
                for (int i = 0; i < humans.Count; i++ )
                {
                    if (humans[i].lastname.Equals(lastname[j]))
                    {
                        temp0 = humans[j].firstname;
                        temp1 = humans[j].lastname;
                        temp2 = humans[j].interest;
                        gender=humans[j].gender;
                        humans[j].firstname = humans[i].firstname;
                        humans[j].lastname = humans[i].lastname;
                        humans[j].interest = humans[i].interest;
                        humans[j].gender = humans[i].gender;
                        humans[i].firstname = temp0;
                        humans[i].lastname = temp1;
                        humans[i].interest = temp2;
                        humans[i].gender = gender;

                    }
                }
                  
            }
            Console.WriteLine("Elements sorted by last names successufully");
        }

        //Set the value of gender
        private static void ChangeGender(ref Human._gender gender)
        {
            Console.WriteLine("Enter \"1\" to set male gender, \"2\" - to set female gender");
            int x;
            string choise = Console.ReadLine();
            try
            {
                int.TryParse(choise, out x);
                switch (x)
                {
                    case 1:
                        {
                            gender = Human._gender.male;
                            break;
                        }
                    case 2:
                        {
                            gender = Human._gender.female;
                            break;
                        }
                    default:
                        {
                            Console.Write("You entered incorrect number and gender set in \"male\". You may use operation \"Set\" to change any parametr");
                            gender = Human._gender.male;
                            break;
                        }
                }
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        
        
    }

    class OutOfRangeException: Exception  {}
    class InvalidParametrException : Exception { }
}
