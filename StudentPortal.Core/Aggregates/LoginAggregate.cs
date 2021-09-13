using StudentPortal.Abstraction.Models;
using StudentPortal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.Core.Aggregates
{
  public  class LoginAggregate : BaseAggregate<Login>
    {
        public LoginAggregate(Login entity) : base(entity)
        {

        }

        private List<string> ValidateLogin(Login login)
        {
            if (string.IsNullOrEmpty(login.Username))
            {
                AddValidationMessage("Username is Required");
            }
            if(string.IsNullOrEmpty(login.Password))
            {
                AddValidationMessage("Password is Required");
            }

            return ValidationMessages;
        }

        public List<string> AddLogin(Login login)
        {
            ValidateLogin(login);
            if (ValidationMessages.Count < 1)
            {
                SetDetails(login);
            }

            return ValidationMessages;
        }
        public List<string> UpdateLogin(Login login)
        {
            ValidateLogin(login);
            if (ValidationMessages.Count < 1)
            {
                SetDetails(login);
            }
            return ValidationMessages;
        }

        private void SetDetails(Login login)
        {
          
            Entity.Id = login.Id;
            Entity.Username = login.Username;
            Entity.Password = login.Password;
        }




    }
}
