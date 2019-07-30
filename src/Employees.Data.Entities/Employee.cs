using Data.Entities;
using System;
using System.ComponentModel;

namespace Employees.Data.Entities
{
    public class Employee : Entity, ISoftDelete
    {
        public string FirstName { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public DateTimeOffset? Deleted { get; set; }

        public string DeleteBy { get; set; }
    }
}
