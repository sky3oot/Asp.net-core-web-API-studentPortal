using StudentPortal.Abstraction.Models;
using StudentPortal.Abstraction.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Abstraction.Repository
{
 public   interface ILoginRepository
    {
        Task SaveLogin(Login login);

        Task UpdateLogin(Login login);

        Task DeleteLogin(Guid Id);

        Task <IEnumerable<Login>> GetAllLoginDetails();

        Task<Login> GetLogin(Guid id);



    }
}
