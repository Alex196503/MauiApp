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
        readonly SQLiteAsyncConnection _database;
        
        public MemberDatabase(String dbPath)
        {
            _database= new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Member>().Wait();
            _database.CreateTableAsync<Membership>().Wait();
        }
        public Task <int> SaveMembershipAsync(Membership membership)
        {
            if (membership == null)
                throw new ArgumentNullException(nameof(membership));
            if (membership.ID!=0)
            {
                return _database.UpdateAsync(membership);
            }
            else
            {
                return _database.InsertAsync(membership);
            }
        }
        public Task <int> DeleteMembershipAsync(Membership membership)
        {
            return _database.DeleteAsync(membership);
        }
        public Task <List<Membership>> GetMembershipsAsync()
        {
            return _database.Table<Membership>().ToListAsync();
        }

        public Task <List<Member>> GetMembersAsync()
        {
            return _database.Table<Member>().ToListAsync();
        }
        public Task <Member> GetMemberAsync(int id)
        {
            return _database.Table<Member>().
                Where(i=>i.ID==id)
                .FirstOrDefaultAsync();
        }
        public Task <int> SaveMemberAsync(Member member)
        {
            if(member.ID!=0)
            {
                return _database.UpdateAsync(member);
            }
            else
            {
                return _database.InsertAsync(member);
            }
        }
        public Task <int> DeleteMemberAsync(Member member)
        {
            return _database.DeleteAsync(member);
        }
        public Task<List<Membership>> GetMembersAsync(int memberid)
        {
            return _database.QueryAsync<Membership>(
        "SELECT membership.ID, membership.MembershipName FROM Membership membership " +
        "INNER JOIN Member M ON M.MembershipID = membership.ID " +  
        "WHERE M.ID = ?", memberid);
        }

    }
    
}
