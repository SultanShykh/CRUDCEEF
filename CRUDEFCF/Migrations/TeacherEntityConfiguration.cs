using CRUDEFCF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CRUDEFCF.Migrations
{
    public class TeacherEntityConfiguration: EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfiguration() 
        {
            this.ToTable("Teachers");

            this.Property(p => p.Name).HasMaxLength(60).IsRequired();
        }
    }
}