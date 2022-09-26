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

        public CourseInstanceService(ICourseInstanceRepository courseInstanceRepository 
            )
        {
            _courseInstanceRepository = courseInstanceRepository;
        }

        public async Task<(CourseInstance, char)> AddCourseInstanceIfNotExistsAsync(CourseInstance courseInstance)
        {
            var foundCorse = await _courseInstanceRepository.GetCourseInstanceIfExistsAsync(courseInstance);
            if (foundCorse == null)
            {
                return (await _courseInstanceRepository.AddCourseInstanceAsync(courseInstance), 'n');
                
            }
            return (foundCorse, 'd');
        }
    }
}
