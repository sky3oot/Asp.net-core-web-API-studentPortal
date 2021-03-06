using System;
using System.Collections.Generic;
using System.Text;

namespace StudentPortal.Abstraction.Models.Entities
{
   public interface ILoginEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
