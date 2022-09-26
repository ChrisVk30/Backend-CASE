using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using CourseEnv.Core.Services;
using Moq;
using System.Globalization;
using System.Reflection.Metadata;

namespace CourseEnv.Core.Tests
{
    [TestClass]
    public class CourseInstanceServiceTests
    {
        Mock<ICourseInstanceRepository> mockInstanceRepository;
        ICourseInstanceService sut;
        CourseInstance courseInstance;
        DateTime startDate;

        [TestInitialize]
        public void TestInitialize()
        {
            mockInstanceRepository = new Mock<ICourseInstanceRepository>();
            sut = new CourseInstanceService(mockInstanceRepository.Object );
            courseInstance = new CourseInstance() { CourseId = 1, CourseInstanceId = 0, StartDate = startDate };
            startDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        [TestMethod]
        public async Task AddCourseInstanceIfNotExistsAsync_ShouldReturnTupleOfFoundInstanceAndDWhenCourseInstanceAlreadyExists()
        {
            var courseInstanceFound = new CourseInstance() { CourseId=1, CourseInstanceId=10, StartDate=startDate };
            //{ Title = "C# Programmeren", CourseCode = "CNETIN", Duration = 5, CourseId = 5 };
            mockInstanceRepository.Setup(x => x.GetCourseInstanceIfExistsAsync(courseInstance)).ReturnsAsync(courseInstanceFound);

            var actual = await sut.AddCourseInstanceIfNotExistsAsync(courseInstance);

            mockInstanceRepository.Verify(x => x.GetCourseInstanceIfExistsAsync(It.IsAny<CourseInstance>()), Times.Once());
            mockInstanceRepository.Verify(x => x.AddCourseInstanceAsync(It.IsAny<CourseInstance>()), Times.Never());
            Assert.AreEqual(actual.Item2, 'd');
            Assert.AreEqual(actual.Item1.CourseId, courseInstance.CourseId);
        }

        [TestMethod]
        public async Task AddCourseInstanceIfNotExistsAsync_ShouldReturnTupleOfGivenCourseInstanceAndNWhenCourseInstanceDoesNotExist()
        {
            //{ Title = "C# Programmeren", CourseCode = "CNETIN", Duration = 5, CourseId = 5 };
            mockInstanceRepository.Setup(x => x.GetCourseInstanceIfExistsAsync(courseInstance)).ReturnsAsync(value: null);
            mockInstanceRepository.Setup(x => x.AddCourseInstanceAsync(courseInstance)).ReturnsAsync(courseInstance);

            var actual = await sut.AddCourseInstanceIfNotExistsAsync(courseInstance);

            mockInstanceRepository.Verify(x => x.GetCourseInstanceIfExistsAsync(It.IsAny<CourseInstance>()), Times.Once());
            mockInstanceRepository.Verify(x => x.AddCourseInstanceAsync(It.IsAny<CourseInstance>()), Times.Once());
            Assert.AreEqual(actual.Item2, 'n');
            Assert.AreEqual(actual.Item1.CourseId, courseInstance.CourseId);
        }
    }
}
