using CourseEnv.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CourseEnv.Infrastructure.Data
{
    public class CourseContext : DbContext
    {
        public int? DatePart(string datePartArg, DateTimeOffset? date) => throw new InvalidOperationException($"{nameof(DatePart)} cannot be called client side.");
        public CourseContext() { }
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseInstance> CourseInstances { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder
                    .AddJsonFile("appsettings.json");
                var connectionString = builder.Build();

                optionsBuilder.UseSqlServer(connectionString.GetConnectionString("CourseAppDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CourseInstanceMapping());
            modelBuilder.ApplyConfiguration(new CourseMapping());

            var methodInfo = typeof(DbFunctionExtensions).GetMethod(nameof(DatePart));

            var datePartMethodInfo = typeof(CourseContext) 
                .GetRuntimeMethod(nameof(CourseContext.DatePart), new[] { typeof(string), typeof(DateTimeOffset) });
            
            modelBuilder.HasDbFunction(datePartMethodInfo)
               .HasTranslation(args =>
                        new SqlFunctionExpression("DATEPART",
                            new[]
                            {
                            new SqlFragmentExpression((args.ToArray()[0] as SqlConstantExpression).Value.ToString()),
                            args.ToArray()[1]
                            },
                            true,
                            new[] { false, false },
                            typeof(int?),
                            null
                        )
                    );
        }

    }
}
