using Employees.Data.Entities;
using ExtCore.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Data.EntityFramework.SqlServer
{
    public class EntityRegistrar : IEntityRegistrar
    {
        public void RegisterEntities(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Employee>(etb => {
                etb.ToTable("Employees");
                etb.HasKey(e => e.Id);
                etb.Property(e => e.Id).ValueGeneratedOnAdd();

                etb.Property(p => p.FirstName).HasMaxLength(64).IsRequired();
                etb.Property(p => p.FullName).HasMaxLength(128);
                etb.Property(p => p.Username).HasMaxLength(64).IsRequired();

                etb.HasQueryFilter(m => m.IsDeleted == false);
            });
        }
    }
}
