using CourseEnv.Core.Entities;

namespace CourseEnv.Core.Interfaces
{
    public interface ICourseFactory
    {
        Course CreateCourse(CourseOverview courseOverview);
        CourseInstance CreateCourseInstance(DateTime startDate, int Id);
        CourseOverview CreateCourseOverview(object obj);
    }
}