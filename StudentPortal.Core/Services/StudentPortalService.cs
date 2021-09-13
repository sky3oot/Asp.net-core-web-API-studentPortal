using StudentPortal.Abstraction.Models;
using StudentPortal.Abstraction.Repository;
using StudentPortal.Abstraction.Services;
using StudentPortal.Core.Aggregates;
using StudentPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Core.Services
{
  public  class StudentPortalService : IStudentPortalServices
    {

        private ILoginRepository _loginRepository;

            public StudentPortalService(ILoginRepository loginRepository)
        {

            _loginRepository = loginRepository;

        }


        
        public void DeleteLogin(Guid id)
        {
            _loginRepository.DeleteLogin(id);
        }

        public async Task<Login> GetLogin(Guid id)
        {
            var entity = await _loginRepository.GetLogin(id) as Login;
            if(entity   != null)
            {
                var LoginDto = new Login
                {
                    Id = entity.Id,
                    Username = entity.Username,
                    Password = entity.Password
                };
                return LoginDto;
            }
            return null;
        
        }

        public List<string> SaveLogin(Login login)
        {
            var entity = new Login{Id = Guid.NewGuid()};
            var aggregate = new LoginAggregate(entity);
            aggregate.AddLogin(login);
            if(aggregate.ValidationMessages.Count < 1)
            {
                _loginRepository.SaveLogin(aggregate.Entity);
            }
            return aggregate.ValidationMessages;

        }

        public List<string> UpdateLogin(Login login)
        {

      
                var entity = new Login { Id = Guid.NewGuid() };
                var aggregate = new LoginAggregate(entity);
                aggregate.UpdateLogin(login);
                if (aggregate.ValidationMessages.Count < 1)
                {

                    _loginRepository.UpdateLogin(aggregate.Entity);
                }
                return aggregate.ValidationMessages;

            
        }
    }
}
