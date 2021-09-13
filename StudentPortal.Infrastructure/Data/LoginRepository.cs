
using MongoDB.Driver;
using StudentPortal.Abstraction.Models;
using StudentPortal.Abstraction.Models.Entities;
using StudentPortal.Abstraction.Repository;
using StudentPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Infrastructure.Data
{
    public class LoginRepository : ILoginRepository
    {

        MongoContext context;




        public LoginRepository()
        {
            context = new MongoContext();


        }

        public async Task DeleteLogin(Guid Id)
        {
            var filter = Builders<Login>.Filter.Eq("_id", Id);
            await context.Logins.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<Login>> GetAllLoginDetails()
        {
            return (await context.Logins.FindAsync(Logins => true)).ToList();
        }

        public async Task<Login> GetLogin(Guid id)
        {
            var filter = Builders<Login>.Filter.Eq("_id", id);
            return (await context.Logins.FindAsync(filter)).FirstOrDefault();
        }

        public async Task SaveLogin(Login login)
        {
            login.Id = Guid.NewGuid();
            await context.Logins.InsertOneAsync(login as Login);
        }

        public async Task UpdateLogin(Login login)
        {
            var filter = Builders<Login>.Filter.Eq("_id",login.Id);


            await context.Logins.ReplaceOneAsync(filter, login as Login);
        }
    }
}
