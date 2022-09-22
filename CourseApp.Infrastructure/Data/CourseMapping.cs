using CourseEnv.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Infrastructure.Data
{
    internal class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .Property(x => x.CourseCode)
                .HasMaxLength(10);

            builder
                .Property(x => x.Title)
                .HasMaxLength(300);

            List<Course> courses = new List<Course>()
            {
                new Course{CourseId = 1, Duration = 5, CourseCode = "CNETIN", Title = "Programming C#"},
                new Course{CourseId = 2, Duration = 2, CourseCode = "ECMASWN", Title = "ECMAscript – What’s new"},
                new Course{CourseId = 3, Duration = 5, CourseCode = "QSQLS", Title = "Querying SQL Server"},
                new Course{CourseId = 4, Duration = 2, CourseCode = "JPA", Title = "Java Persistence API"},
                new Course{CourseId = 5, Duration = 3, CourseCode = "SPAVUE", Title = "Building a SPA with Vuejs"},
                new Course{CourseId = 6, Duration = 5, CourseCode = "ASPMVC", Title = "ASP.NET MVC"},
            };

            builder.HasData(courses);
        }
    }
}
