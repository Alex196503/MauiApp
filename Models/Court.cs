using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MauiAppBazaSportiva.Models
{
    public class Court
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        [OneToMany]
        public List<Reservation> Reservations { get; set; }
    }
}
