using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MauiAppBazaSportiva.Models
{
    public class Member
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength (100)]
        public string LastName { get; set; }
        [MaxLength (100)]
        public string Email { get; set; }

        public int Age { get; set; }
        [ForeignKey(typeof(Membership))]
        public int MembershipID { get; set; }

        [ForeignKey(typeof(Trainer))]
        public int TrainerID { get; set; }
        [ManyToOne]
        public Membership Membership { get; set; }
        [ManyToOne]
        public Trainer Trainer { get; set; }

            
    }
}
