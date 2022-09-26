using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using CourseEnv.Core.Services;
using Moq;

namespace CourseEnv.Core.Tests
{
    [TestClass]
    public class CourseServiceTests
    {
        Mock<ICourseRepository> mockCourseRepository;
        ICourseService sut;
        Course course;

        [TestInitialize]
        public void TestInitialize()
        {
            mockCourseRepository = new Mock<ICourseRepository>();
            sut = new CourseService(mockCourseRepository.Object);

            course = new Course() { Title = "C# Programmeren", CourseCode = "CNETIN", Duration = 5, CourseId = 0 };
        }
        [TestMethod]

        public async Task CreateCourseFromObjectAsync_ShouldReturnTupleOfFoundCourseAndDWhenCourseAlreadyExists()
        {
            var courseFound = new Course() { Title = "C# Programmeren", CourseCode = "CNETIN", Duration = 5, CourseId = 1 };
            mockCourseRepository.Setup(x => x.GetCourseByCoursecodeAsync(course)).ReturnsAsync(courseFound);

            var actual = await sut.AddCourseIfNotExistsAsync(course);

            mockCourseRepository.Verify(x => x.GetCourseByCoursecodeAsync(It.IsAny<Course>()), Times.Once());
            mockCourseRepository.Verify(x => x.AddCourseAsync(It.IsAny<Course>()), Times.Never());
            Assert.AreEqual(actual.Item2, 'd');
            Assert.AreEqual(actual.Item1.CourseId, courseFound.CourseId);
        }

        [TestMethod]
        public async Task CreateCourseFromObjectAsync_ShouldReturnTupleOfFoundAddedCourseAndNWhenCourseDoesNotExist()
        {
            mockCourseRepository.Setup(x => x.GetCourseByCoursecodeAsync(course)).ReturnsAsync(value: null);
            mockCourseRepository.Setup(x => x.AddCourseAsync(course)).ReturnsAsync(course);

            var actual = await sut.AddCourseIfNotExistsAsync(course);

            mockCourseRepository.Verify(x => x.GetCourseByCoursecodeAsync(It.IsAny<Course>()), Times.Once());
            mockCourseRepository.Verify(x => x.AddCourseAsync(It.IsAny<Course>()), Times.Once());
            Assert.AreEqual(actual.Item2, 'n');
            Assert.AreEqual(actual.Item1.CourseId, course.CourseId);
        }
    }
}
