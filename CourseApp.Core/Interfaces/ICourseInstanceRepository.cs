using CourseEnv.Core.Entities;

namespace CourseEnv.Core.Interfaces
{
    public interface ICourseInstanceRepository
    {
        Task<CourseInstance> AddCourseInstanceAsync(CourseInstance courseInstance);
        Task<CourseInstance> GetCourseInstanceIfExistsAsync(CourseInstance courseInstance);
    }
}