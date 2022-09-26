using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Web.Helpers;
using System.Xml.Linq;

namespace CourseApp.APIs
{
    [Route("api/courses")]
    [ApiController]
    public class CourseAPI
    {
        private ICourseRepository _courseRepository;
        private ICourseFactory _courseFactory;
        private ICourseService _courseService;
        private ICourseInstanceService _courseInstanceService;
        public CourseAPI(ICourseRepository courseRepository, ICourseFactory courseFactory, ICourseService courseService, ICourseInstanceService courseInstanceService )
        {
            _courseRepository = courseRepository;
            _courseFactory = courseFactory;
            _courseService = courseService;
            _courseInstanceService = courseInstanceService;
        }
        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<CourseOutputData>> GetCoursesAsync()
        {
            return await _courseRepository.GetAllCoursesAsync();
        }
        [HttpGet]
        [Route("weekyear")]
        public async Task<IEnumerable<CourseOutputData>> GetCoursesByWeekAndYear(int week, int year)
        {
            return await _courseRepository.GetCoursesByWeekAndYear(week, year);
        }

        [HttpPost]
        public async Task<CoursesAddedStats> AddCoursesFromFileAsync(object[] objects)
        {
            var stats = new CoursesAddedStats();
            foreach(object obj in objects) {
                var courseOverview = _courseFactory.CreateCourseOverview(obj);
                var createdCourse = _courseFactory.CreateCourse(courseOverview);
                var course = await _courseService.AddCourseIfNotExistsAsync(createdCourse);
                stats.CoursesAdded += course.Item2;
                var createdCourseInstance = _courseFactory.CreateCourseInstance(courseOverview.StartDate, course.Item1.CourseId);
                var courseInstance = await _courseInstanceService.AddCourseInstanceIfNotExistsAsync(createdCourseInstance);
                stats.CourseInstancesAdded += courseInstance.Item2;
            }
            return stats;
        }
    }
}
