using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORMBlog
{
    public class Person
    {
        public int PersonID{ get; set;} 
        public  string LastName { get; set; }
        public  string FirstName { get; set; }
        public  DateTime HireDate { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
