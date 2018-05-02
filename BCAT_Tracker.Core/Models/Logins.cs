using System;
using System.Text;
using SQLite;

namespace BCAT_Tracker.Core.Models
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
}
