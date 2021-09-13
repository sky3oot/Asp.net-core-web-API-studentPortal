using StudentPortal.Abstraction.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.Core.Entities
{
    public class LoginEntity : ILoginEntity
    {
        public Guid Id { get ; set ; }
        public string Username { get; set ; }
        public string Password { get ; set ; }
    }
}
