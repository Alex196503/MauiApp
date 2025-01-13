using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using MauiAppBazaSportiva.Models;
namespace MauiAppBazaSportiva.Data
{
    public class MemberDatabase
    {
        IRestService restService;
        readonly SQLiteAsyncConnection _database;
        public MemberDatabase(IRestService service,string dbPath)
        {
            restService = service;
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Member>().Wait();
            _database.CreateTableAsync<Membership>().Wait();
            _database.CreateTableAsync<Trainer>().Wait();
            _database.CreateTableAsync<Reservation>().Wait();
            _database.CreateTableAsync<Review>().Wait();
            _database.CreateTableAsync<Court>().Wait();


        }
        public Task<List<Member>> GetMembersAsync()
        {
            return _database.Table<Member>().ToListAsync();
        }
        public Task<Member> GetMemberAsync(int id)
        {
            return _database.Table<Member>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveMemberAsync(Member member)
        {
            if (member.ID != 0)
            {
                return _database.UpdateAsync(member);
            }
            else
            {
                return _database.InsertAsync(member);
            }
        }
        public Task<int> DeleteMemberAsync(Member member)
        {
            return _database.DeleteAsync(member);
        }
        public Task<int> SaveMembershipAsync(Membership membership)
        {
            if (membership.ID != 0)
            {
                return _database.UpdateAsync(membership);
            }
            else
            {
                return _database.InsertAsync(membership);
            }
        }
        public Task<int> DeleteMembershipAsync(Membership membership)
        {
            return _database.DeleteAsync(membership);
        }
        public Task<List<Membership>> GetMembershipsAsync()
        {
            return _database.Table<Membership>().ToListAsync();
        }

        public Task<List<Membership>> GetMemberMembershipsAsync(int memberid)
        {
            return _database.QueryAsync<Membership>(
     "SELECT M.ID, M.Name, M.StartingDate, M.EndDate " +
     "FROM Membership M " +
     "INNER JOIN Member MB " +
     "ON M.ID = MB.MembershipID " +
     "WHERE MB.ID = ?",
     memberid);
        }
        public Task<int> SaveTrainerAsync(Trainer trainer)
        {
            if (trainer.ID != 0)
            {
                return _database.UpdateAsync(trainer);
            }
            else
            {
                return _database.InsertAsync(trainer);
            }
        }
        public Task<int> DeleteTrainerAsync(Trainer trainer)
        {
            return _database.DeleteAsync(trainer);
        }
        public Task<List<Trainer>> GetTrainersAsync()
        {
            return _database.Table<Trainer>().ToListAsync();
        }
        public Task<List<Trainer>> GetMemberTrainersAsync(int memberid)
        {
            return _database.QueryAsync<Trainer>("select T.ID, T.Name, T.Specialization from Trainer T "
                                        + "inner join Member M "
                                        + "on T.ID = M.TrainerID where M.ID = ?", memberid);

        }
        public Task<int> SaveReservationAsync(Reservation reservation)
        {
            if (reservation.ID != 0)
            {
                return _database.UpdateAsync(reservation);
            }
            else
            {
                return _database.InsertAsync(reservation);
            }
        }
        public Task<int> DeleteReservationAsync(Reservation reservation)
        {
            return _database.DeleteAsync(reservation);
        }
        public Task<List<Reservation>> GetReservationsAsync()
        {
            return _database.Table<Reservation>().ToListAsync();
        }
        public Task<List<Reservation>> GetReservationsForMemberAsync(int memberId)
        {
            return _database.QueryAsync<Reservation>(
                "SELECT R.ID, R.Duration, R.ReservationDate from Reservation R "
                + "INNER JOIN Member M ON R.ID = M.ReservationID " +
                "WHERE M.ID = ?",
                memberId);
        }
        public Task<int> SaveReviewAsync(Review review)
        {
            if (review.ID != 0)
            {
                return _database.UpdateAsync(review);
            }
            else
            {
                return _database.InsertAsync(review);
            }
        }
        public Task<int> DeleteReviewAsync(Review review)
        {
            return _database.DeleteAsync(review);
        }
        public Task<List<Review>> GetReviewsAsync()
        {
            return _database.Table<Review>().ToListAsync();
        }
        public Task<List<Review>> GetReviewForTrainersAsync(int trainerid)
        {
            return _database.QueryAsync<Review>(
     "SELECT R.ID, R.Comment, R.Rating, R.ReviewDate FROM Review R " +
     "INNER JOIN Trainer T ON R.ID=T.ReviewID " +
     "WHERE T.ID = ?", trainerid);

        }
        public Task<int> SaveCourtAsync(Court court)
        {
            if (court.ID != 0)
            {
                return _database.UpdateAsync(court);
            }
            else
            {
                return _database.InsertAsync(court);
            }
        }
        public Task<int> DeleteCourtAsync(Court court)
        {
            return _database.DeleteAsync(court);
        }
        public Task<List<Court>> GetCourtsAsync()
        {
            return _database.Table<Court>().ToListAsync();
        }
        public Task <List<Court>> GetCourtsForReservation(int reservationid)
        {
            return _database.QueryAsync<Court>(
                "select C.ID,C.Type,C.Size from Court C"
                + " inner join Reservation R "
                + "on C.ID=R.CourtID where R.ID=?", reservationid);
           
        }
        public Task<List<Member>> GetMembersFromRestAsync()
        {
            return restService.RefreshDataAsync();
        }
       
        
    }
}



