using System;
using System.Text;
using SQLite;
using System.Collections.Generic;

namespace BCAT_Tracker.Core 
{
    [Table("Logins")]
    public class Logins
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }




    public class UserContext
    { 
        public string token { get; set; }

        
        public string username { get; set; }

        public int usertype { get; set; }

        public int apptype { get; set; }
    }
    public class GetSafetyNote : UserContext
    { 
        public List<int> patientid { get; set; }
    }
}
