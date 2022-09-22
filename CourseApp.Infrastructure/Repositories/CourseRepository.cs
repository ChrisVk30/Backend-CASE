using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using CourseEnv.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CourseEnv.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private CourseContext _context;
        public CourseRepository(CourseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CourseOutputData>> GetAllCoursesAsync()
        {
            var allcourses =
                        (from course in _context.Courses
                         join courseInstance in _context.CourseInstances
                         on course.CourseId equals courseInstance.CourseId
                         select new CourseOutputData { Duration = course.Duration, StartDate = courseInstance.StartDate, Title = course.Title }).Distinct().OrderBy(s => s.StartDate).ToList();

            return allcourses;
        }

        public async Task<IEnumerable<CourseOutputData>> GetCoursesByWeekAndYear(int week, int year)
        {
            var coursesByWeekYear =
                         (from course in _context.Courses
                          join courseInstance in _context.CourseInstances
                          on course.CourseId equals courseInstance.CourseId
                          where (_context.DatePart("week", courseInstance.StartDate) == week && (_context.DatePart("year", courseInstance.StartDate) == year))
                          select new CourseOutputData { Duration = course.Duration, StartDate = courseInstance.StartDate, Title = course.Title }).Distinct().OrderBy(s => s.StartDate).ToList();
            return coursesByWeekYear;
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> GetCourseByCoursecodeAsync(Course course)
        {
            return await _context.Courses.SingleOrDefaultAsync(x => x.CourseCode == course.CourseCode);
        }
    }
}