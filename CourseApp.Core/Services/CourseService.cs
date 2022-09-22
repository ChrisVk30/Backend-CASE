using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;

namespace CourseEnv.Core.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;
        private ICourseFactory _courseFactory;
        public CourseService(ICourseRepository courseRepository, ICourseFactory courseFactory)
        {
            _courseRepository = courseRepository;
            _courseFactory = courseFactory;
        }
        public async Task<Course> CreateCourseFromObjectAsync(CourseOverview courseOverview)
        {
            return _courseFactory.CreateCourse(courseOverview);
        }

        public async Task<(Course, char)> AddCourseIfNotExistsAsync(Course course)
        {
            var foundCorse = await _courseRepository.GetCourseByCoursecodeAsync(course);
            if (foundCorse == null)
            {
                return (await _courseRepository.AddCourseAsync(course), 'n');
            }
            return (foundCorse, 'd');
        }
    }
}
