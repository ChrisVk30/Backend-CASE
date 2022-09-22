using CourseEnv.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Infrastructure.Data
{
    public class CourseInstanceMapping : IEntityTypeConfiguration<CourseInstance>
    {
        DateTime date;
        public void Configure(EntityTypeBuilder<CourseInstance> builder)
        {
            builder.HasOne(i => i.Course)
                .WithMany(c => c.CourseInstances)
                .HasForeignKey(c => c.CourseId);

            builder
                .Property(i => i.StartDate)
                .HasColumnType("date");

            List<CourseInstance> courseInstances = new List<CourseInstance>()
            {
                new CourseInstance{CourseId = 1, CourseInstanceId = 1, StartDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new CourseInstance{CourseId = 2, CourseInstanceId = 2, StartDate = DateTime.ParseExact("26/08/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new CourseInstance{CourseId = 3, CourseInstanceId = 3, StartDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new CourseInstance{CourseId = 4, CourseInstanceId = 4, StartDate = DateTime.ParseExact("10/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new CourseInstance{CourseId = 5, CourseInstanceId = 5, StartDate = DateTime.ParseExact("31/08/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture)},
                new CourseInstance{CourseId = 6, CourseInstanceId = 6, StartDate = DateTime.ParseExact("08/09/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture)}
            };

            builder.HasData(courseInstances);
        }
    }
}
