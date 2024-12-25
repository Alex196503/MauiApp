using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MauiAppBazaSportiva.Models
{
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(100),Unique]
        public string FirstName { get; set; }
        [MaxLength (100),Unique]
        public string LastName { get; set; }
        [MaxLength (100),Unique]
        public string Email { get; set; }

        public int Age { get; set; }
            public string FullName => $"{FirstName} {LastName}";


    }
}
