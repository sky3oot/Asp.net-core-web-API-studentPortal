using StudentPortal.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal.Abstraction.Services
{
   public interface IStudentPortalServices
    {
        List<string> SaveLogin(Login login);
        List<string> UpdateLogin(Login login);

        Task<Login> GetLogin(Guid id);

        void DeleteLogin(Guid id);
    }
}
