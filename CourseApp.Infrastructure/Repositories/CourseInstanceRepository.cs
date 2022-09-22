using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using CourseEnv.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Infrastructure.Repositories
{
    public class CourseInstanceRepository : ICourseInstanceRepository
    {
        private CourseContext _context;
        public CourseInstanceRepository(CourseContext context)
        {
            _context = context;
        }

        public async Task<CourseInstance> AddCourseInstanceAsync(CourseInstance courseInstance)
        {
            _context.Add(courseInstance);
            await _context.SaveChangesAsync();
            return courseInstance;
        }

        public async Task<CourseInstance> GetCourseInstanceIfExistsAsync(CourseInstance courseInstance)
        {
            return await _context.CourseInstances.SingleOrDefaultAsync(x => x.StartDate == courseInstance.StartDate && x.CourseId == courseInstance.CourseId);

        }
    }
}
