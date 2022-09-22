using CourseEnv.Core.Entities;
using CourseEnv.Core.Factories;
using CourseEnv.Core.Interfaces;
using CourseEnv.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Core.Tests
{
    [TestClass]
    public class CourseInstanceServiceTests
    {
        Mock<ICourseInstanceRepository> mockInstanceRepository;
        Mock<ICourseRepository> mockCourseRepository;
        Mock<ICourseFactory> mockCourseFactory;
        CourseInstanceService sut;

        [TestInitialize]
        public void TestInitialize()
        {
            mockInstanceRepository = new Mock<ICourseInstanceRepository>();
            mockCourseRepository = new Mock<ICourseRepository>();   
            mockCourseFactory = new Mock<ICourseFactory>();
            sut = new CourseInstanceService(mockInstanceRepository.Object, mockCourseFactory.Object, mockCourseRepository.Object);
        }

        [TestMethod]
        public void Something()
        {
              
        }
    }
}
