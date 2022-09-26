using CourseEnv.Core.Entities;

namespace CourseEnv.Core.Interfaces
{
    public interface ICourseInstanceService
    {
        Task<(CourseInstance, char)> AddCourseInstanceIfNotExistsAsync(CourseInstance courseInstance);
    }
}