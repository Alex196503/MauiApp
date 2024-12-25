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
    }
}
