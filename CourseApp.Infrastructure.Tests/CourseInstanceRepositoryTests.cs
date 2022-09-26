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
    public class CourseInstanceRepositoryTests
    {
        private SqliteConnection connection;
        private DbContextOptions<CourseContext> _options = null;
        ICourseInstanceRepository sut;
        Mock<CourseContext> mockContext;
        Mock<DbSet<CourseInstance>> mockSet;
        CourseInstance courseInstance;
        DateTime startDate;

        [TestInitialize]
        public void TestInitialize() {
            mockContext = new Mock<CourseContext>();
            sut = new CourseInstanceRepository(mockContext.Object);
            mockSet = new Mock<DbSet<CourseInstance>>();
            courseInstance = new CourseInstance() { CourseId = 1, CourseInstanceId = 0, StartDate = startDate };
            startDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
        public void AddCourseInstanceAsync_ShouldAddInstanceToDbAndReturnTheInstance_MockVersion()
        {
            mockContext.Setup(x => x.CourseInstances).Returns(mockSet.Object);

            var courseReturned = sut.AddCourseInstanceAsync(courseInstance);

            mockContext.Verify(x => x.AddRangeAsync(It.IsAny<CourseInstance>()), Times.Once());
            mockContext.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
            Assert.IsNotNull(courseReturned);
        }

        [TestMethod]
        public async Task AddCourseInstanceAsync_ShouldAddInstanceToDbAndReturnTheInstance_SQLiteVersion()
        {
            using (var context = new CourseContext(_options))
            {
                context.Database.EnsureCreated();
                var sutLite = new CourseInstanceRepository(context);
                context.SaveChanges();
                var addedCourseInstance = await sutLite.AddCourseInstanceAsync(courseInstance);
                Assert.IsTrue(context.CourseInstances.Count() == 7);
                Assert.IsNotNull(addedCourseInstance);
                Assert.IsTrue(addedCourseInstance.CourseInstanceId == 7);
            }
        }

        [TestMethod]

        public async Task GetCourseInstanceIfExistsAsync_ShouldReturnNotNullWhenCourseInstanceAlreadyExists()
        {
            var courseInstance = new CourseInstance() { CourseId = 1, StartDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) };
            using (var context = new CourseContext(_options))
            {
                context.Database.EnsureCreated();
                var sutLite = new CourseInstanceRepository(context);
                context.SaveChanges();
                var courseFound = await sutLite.GetCourseInstanceIfExistsAsync(courseInstance);
                Assert.IsNotNull(courseFound.CourseInstanceId);
            }
        }

        [TestMethod]

        public async Task GetCourseInstanceIfExistsAsync_ShouldReturnNullWhenCourseInstanceDoesNotExist()
        {
            var courseInstance = new CourseInstance() { CourseId = 2, StartDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) };
            using (var context = new CourseContext(_options))
            {
                context.Database.EnsureCreated();
                var sutLite = new CourseInstanceRepository(context);
                context.SaveChanges();
                var courseFound = await sutLite.GetCourseInstanceIfExistsAsync(courseInstance);
                Assert.IsNull(courseFound);
            }
        }
    }
}
