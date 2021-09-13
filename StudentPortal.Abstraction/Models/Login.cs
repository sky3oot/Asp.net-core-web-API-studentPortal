using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StudentPortal.Abstraction.Models
{
  
   public class Login
    {

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
