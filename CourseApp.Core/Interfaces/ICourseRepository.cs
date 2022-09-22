using CourseEnv.Core.Entities;

namespace CourseEnv.Core.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseOutputData>> GetAllCoursesAsync();
        Task<IEnumerable<CourseOutputData>> GetCoursesByWeekAndYear(int week, int year);
        Task<Course> AddCourseAsync(Course course);
        Task<Course> GetCourseByCoursecodeAsync(Course course);

    }
}