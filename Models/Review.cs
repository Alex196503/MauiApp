using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace MauiAppBazaSportiva.Models
{
    public class Review
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        [ForeignKey(typeof(Trainer))]
        public int TrainerID { get; set; }

    }
}
