using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MauiAppBazaSportiva.Models
{
    public class Member
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [MaxLength(250),Unique]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Membership))]
        public int MembershipID { get; set; }
        [ManyToOne]
        public Membership Membership { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Trainer))]
        public int TrainerID { get; set; }
        [ManyToOne]
        public Trainer Trainer { get; set; }
        public string Name => $"{FirstName} {LastName}";

    }
}
