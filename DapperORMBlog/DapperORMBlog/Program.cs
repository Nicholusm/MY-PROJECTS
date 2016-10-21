using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace DapperORMBlog
{
    public class Program : Person
    {

        public static void Main(string[] args)
        {
     
         

            CRUD();
            Back();
            Console.ReadLine();
        }

        public static void Back()
        {
            Console.WriteLine("1)  Back");
            Console.WriteLine("2)  Exit");

            int option;
            option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                CRUD();
            }
            else if (option == 2)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Wrong option chosen");
            }
            Console.ReadLine();
        }
        public  static  void CRUD()
        {
            Console.WriteLine("Choose which funationality you will  like to perfom on the table");
            Console.WriteLine("1) View Person List ");
            Console.WriteLine("2) Delete");
            Console.WriteLine("3) Update");
            Console.WriteLine("4) Insert");


            int y;
            y = int.Parse(Console.ReadLine());
            switch (y)
            {
                case 1:
                    try
                    {
                      Repository repo = new Repository();
                        List<Person> persons = repo.GeList();

                        foreach (var pers in persons)
                        {
                            Console.WriteLine("{0,2} {1,2} {2,2} {3,2} {4,2}", "Person ID ", "Last Name " ,"First Name", "Hire Date " ,"Enrollment date");
                            Console.WriteLine("{0,2} {1,2} {2,2} {3,2} {4,2}", pers.PersonID, pers.LastName, pers.FirstName, pers.HireDate,pers.EnrollmentDate);

                            
                        }
                        Back();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                
                    break;

                case 2:
                    Repository repository = new Repository();
                    repository.DeletePerson(0);
                    Back();
                    break;

                case 3:
                    Repository repo1 = new Repository();
                    repo1.UpdatePerson(0,"","");
                    Back();
                    break;

                case 4:
                    Repository repo2 = new Repository();
                  repo2.Addperson("","","","");
                    Back();
                    break;

   

                default:
                    Console.WriteLine("Invalid Option");
                    Back();
                    break;
         
            }
        }

      
    }
}
