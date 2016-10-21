using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperORMBlog
{
    internal class Repository : Person

    {
        //Connection string
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());


        public List<Person> GeList()
        {
            return this.db.Query<Person>("SELECT * FROM Person").ToList();
       
        }

        public bool DeletePerson(int PersonID)
        {
            try
            {
                Console.WriteLine("Enter the person id you will like to delete");

                DynamicParameters param = new DynamicParameters();
                PersonID = int.Parse(Console.ReadLine());
                param.Add("@PersonID", PersonID);
                db.Execute("DeletePerson", param, commandType: CommandType.StoredProcedure);
                db.Close();
                Console.WriteLine("The person Id number {0} has been deleted from the database",PersonID);
                return true;
              
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public void UpdatePerson(int PersonID, string LastName,string FirstName)
        {

            try
            {
                //Console.WriteLine("Enter the PersonId for the person you want to update");
                DynamicParameters parameters = new DynamicParameters();
                
                Console.WriteLine("Update person");
                Console.Write("Last Name : ");
                LastName = Console.ReadLine();
                parameters.Add("@lastname", LastName);
                Console.Write("First Name :");
                FirstName = Console.ReadLine();
                parameters.Add("@firstname",FirstName);
                Console.WriteLine("Enter the person Id you want to update");
                PersonID = int.Parse(Console.ReadLine());
                parameters.Add("@personid", PersonID);
                Console.WriteLine(PersonID);
                db.Execute("UpdatePerson",parameters ,commandType: CommandType.StoredProcedure);
             
                db.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Addperson(string lastname, string firstname, string hiredate, string enrollmentdate)

        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                Console.Write("Last Name : ");
                lastname = Console.ReadLine();
                parameters.Add("@lastname", lastname);
                Console.Write("First Name :");
                firstname = Console.ReadLine();
                parameters.Add("@firstname", firstname);
                Console.Write("enrollmentdate : ");
                enrollmentdate = Console.ReadLine();
                parameters.Add("@enrollmentdate", enrollmentdate);
                parameters.Add("@hiredate", DateTime.Now);
                db.Execute("AddPerson", parameters, commandType: CommandType.StoredProcedure);
                db.Close();
                Console.WriteLine("New Person added to the database");

            }
            catch (Exception ex)
            {
                
            Console.WriteLine(ex.Message);
            }
         
        }
    

    }

    }


    


