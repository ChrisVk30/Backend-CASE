using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using CourseEnv.Infrastructure.Data;
using CourseEnv.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Moq;
using System.Globalization;

namespace CourseEnv.Infrastructure.Tests
{
    [TestClass]
    public class CourseRepositoryTests
    {
        private SqliteConnection connection;
        private DbContextOptions<CourseContext> _options = null;

        [TestInitialize]
        public void TestInitialize()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            _options = new DbContextOptionsBuilder<CourseContext>()
                .UseSqlite(connection)
                .Options;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            connection.Dispose();
        }

        [TestMethod]

        public async Task GetAllCoursesAsync_ShouldReturnAListOf6ItemsOrderedByStartDateAsc()
        {
            using (var context = new CourseContext(_options))
            {
                context.Database.EnsureCreated();
                var sutLite = new CourseRepository(context);
                context.SaveChanges();
                var courses = await sutLite.GetAllCoursesAsync();
                Assert.IsNotNull(courses);
                Assert.IsTrue(courses.Count() == 6);
                Assert.IsTrue(courses.First().Title == "ECMAscript – What’s new");
                Assert.IsTrue(courses.Last().Title == "Java Persistence API");
            }
        }

        [TestMethod]
        public async Task AddCourseAsync_ShouldAddCourseAndMakeTotalRecordsOneHigher()
        {
            using (var context = new CourseContext(_options))
            {
                var course = new Course { CourseCode = "TEST", Duration = 4, Title = "Testing Database" };
                context.Database.EnsureCreated();
                var sutLite = new CourseRepository(context);
                context.SaveChanges();
                var addedCourse = await sutLite.AddCourseAsync(course);
                Assert.IsTrue(context.Courses.Count() == 7);
                Assert.IsNotNull(addedCourse);
                Assert.IsTrue(addedCourse.CourseId == 7);
            }
        }

        [TestMethod]
        public async Task GetCourseByCoursecodeAsync_ShouldNotReturnNullWhenCourseExists()
        {
            using (var context = new CourseContext(_options))
            {
                var course = new Course { CourseCode = "CNETIN", Duration = 1000, Title = "Testing Database" };
                context.Database.EnsureCreated();
                var sutLite = new CourseRepository(context);
                context.SaveChanges();
                var foundCourse = await sutLite.GetCourseByCoursecodeAsync(course);
                Assert.IsNotNull(foundCourse);
                Assert.IsTrue(foundCourse.CourseId == 1);
                Assert.IsTrue(foundCourse.Duration == 5);
            }
        }

        [TestMethod]
        public async Task GetCourseByCoursecodeAsync_ShouldReturnNullWhenCourseDoesNotExist()
        {
            using (var context = new CourseContext(_options))
            {
                var notExisting = new Course { CourseCode = "TEST", Duration = 10, Title = "Testing Database" };
                context.Database.EnsureCreated();
                var sutLite = new CourseRepository(context);
                context.SaveChanges();
                var foundCourse = await sutLite.GetCourseByCoursecodeAsync(notExisting);
                Assert.IsNull(foundCourse);
            }
        }
    }
}
