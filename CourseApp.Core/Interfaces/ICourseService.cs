using CourseEnv.Core.Entities;

namespace CourseEnv.Core.Interfaces
{
    public interface ICourseService
    {
        Task<(Course, char)> AddCourseIfNotExistsAsync(Course course);
        Task<Course> CreateCourseFromObjectAsync(CourseOverview courseOverview);
    }
}