using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace MauiAppBazaSportiva.Models
{
    public class Membership
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string MembershipName { get; set; }
        public DateTime? Data_Start { get; set; }
        public DateTime? Data_Expirare { get; set; }
        [OneToMany]
        public List<Member> Members { get; set; }
    }
}
