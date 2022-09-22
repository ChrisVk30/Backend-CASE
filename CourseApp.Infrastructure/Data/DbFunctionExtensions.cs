using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Infrastructure.Data
{
    public static class DbFunctionExtensions
    {
        public static int? DatePart(string type, DateTime? date) => throw new Exception();

        public static void ConfigureDbFunctions(this ModelBuilder modelBuilder)
        {
            var mi = typeof(DbFunctionExtensions).GetMethod(nameof(DatePart));

            modelBuilder.HasDbFunction(mi, b => b.HasTranslation(e =>
            {
                var ea = e.ToArray();
                var args = new[]
                {
                new SqlFragmentExpression((ea[0] as SqlConstantExpression).Value.ToString()),
                ea[1]
            };
                return SqlFunctionExpression.Create(nameof(DatePart), args, typeof(int?), null);
            }));
        }
    }
}
