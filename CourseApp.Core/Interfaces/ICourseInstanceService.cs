using CourseEnv.Core.Entities;

namespace CourseEnv.Core.Interfaces
{
    public interface ICourseInstanceService
    {
        Task<char> AddCourseInstanceIfNotExistsAsync(CourseInstance courseInstance);
        Task<CourseInstance> CreateCourseInstanceFromObjectAsync(DateTime startDate, Course course);
    }
}