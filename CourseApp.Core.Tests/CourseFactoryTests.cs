using CourseEnv.Core.Entities;
using CourseEnv.Core.Factories;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Core.Tests
{
    [TestClass]
    public class CourseFactoryTests
    {
        CourseFactory sut;
        CourseOverview courseOverview;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new CourseFactory();
            courseOverview = new CourseOverview { CourseCode = "CNETIN", Duration = 2, Title = "C# Programmeren", StartDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) };
        }

        [TestMethod]
        public void ShouldCreateACourseBasedOnCourseOverviewInput()
        {
            var createdCourse = sut.CreateCourse(courseOverview);

            Assert.IsNotNull(createdCourse);
            Assert.AreEqual(createdCourse.CourseCode, "CNETIN");
            Assert.AreEqual(createdCourse.Duration, 2);
            Assert.AreEqual(createdCourse.Title, "C# Programmeren");
            Assert.AreEqual(createdCourse.CourseId, 0);                 // will be filled by Id of already existing record at DB
                                                                        // or generated when adding new course to DB
        }

        [TestMethod]
        public void ShouldCreateACourseInstanceBasedOnCourseOverviewInput()
        {
            var createdCourseInstance = sut.CreateCourseInstance(courseOverview.StartDate, 1);

            Assert.IsNotNull(createdCourseInstance);
            Assert.AreEqual(createdCourseInstance.StartDate, DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            Assert.AreEqual(createdCourseInstance.CourseId, 1);
            Assert.AreEqual(createdCourseInstance.CourseInstanceId, 0); // will be filled by Id of already existing record at DB
                                                                        // or generated when adding new course to DB
        }

        [TestMethod]
        public void ShouldCreateACourseOverviewBasedOnJsonInput()
        {
            var jsonObj = new CourseOverview { Title = "C# Programmeren", CourseCode = "CNETIN", Duration = 5, StartDate = DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture) };
            string json = JsonConvert.SerializeObject(jsonObj);

            var courseOverview = sut.CreateCourseOverview(json);

            Assert.IsNotNull(courseOverview);
            Assert.AreEqual(courseOverview.StartDate, DateTime.ParseExact("08/10/2018", "dd/MM/yyyy", CultureInfo.InvariantCulture));
            Assert.AreEqual(courseOverview.CourseCode, "CNETIN");
            Assert.AreEqual(courseOverview.Duration, 5);
            Assert.AreEqual(courseOverview.Title, "C# Programmeren");

        }
    }
}
