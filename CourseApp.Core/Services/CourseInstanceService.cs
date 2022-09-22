using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Core.Services
{
    public class CourseInstanceService : ICourseInstanceService
    {
        private readonly ICourseInstanceRepository _courseInstanceRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseFactory _courseFactory;
        public CourseInstanceService(ICourseInstanceRepository courseInstanceRepository, ICourseFactory courseFactory, ICourseRepository courseRepository)
        {
            _courseInstanceRepository = courseInstanceRepository;
            _courseFactory = courseFactory;
            _courseRepository = courseRepository;
        }
        public async Task<CourseInstance> CreateCourseInstanceFromObjectAsync(DateTime startDate, Course course)
        {
            var courseFound = await _courseRepository.GetCourseByCoursecodeAsync(course);
            var courseId = courseFound.CourseId;
            return _courseFactory.CreateCourseInstance(startDate, courseId);
        }

        public async Task<char> AddCourseInstanceIfNotExistsAsync(CourseInstance courseInstance)
        {
            var foundCorse = await _courseInstanceRepository.GetCourseInstanceIfExistsAsync(courseInstance);
            if (foundCorse == null)
            {
                await _courseInstanceRepository.AddCourseInstanceAsync(courseInstance);
                return 'n';
            }
            return 'd';
        }
    }
}
