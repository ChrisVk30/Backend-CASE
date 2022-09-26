using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;

namespace CourseEnv.Core.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
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
