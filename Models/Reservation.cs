using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
namespace MauiAppBazaSportiva.Models
{
    public class Reservation
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public DateTime ReservationDate { get; set; }

        public int Duration { get; set; }
        [ForeignKey(typeof(Member))]
        public int MemberID { get; set; }
        [OneToOne]
        public Member Member { get; set; }
        [ForeignKey(typeof(Court))]
        public int CourtID { get; set; }
        [ManyToOne]
        public Court Court { get; set; }

    }
}
