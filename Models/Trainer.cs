using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MauiAppBazaSportiva.Models
{
    public class Trainer
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        [OneToMany]
        public List<Member> Members{ get; set; }
    }
}
