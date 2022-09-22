using CourseEnv.Core.Entities;
using CourseEnv.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Core.Factories
{
    public class CourseFactory : ICourseFactory
    {
        public Course CreateCourse(CourseOverview courseOverview)
        {
            var course = new Course { CourseCode = courseOverview.CourseCode, Duration = courseOverview.Duration, Title = courseOverview.Title };
            return course;
        }

        public CourseInstance CreateCourseInstance(DateTime startDate, int Id)
        {
            var courseInstance = new CourseInstance { CourseId = Id, StartDate = startDate };
            return courseInstance;
        }

        public CourseOverview CreateCourseOverview(object obj)
        {;
            return JsonConvert.DeserializeObject<CourseOverview>(obj.ToString(), 
                   new IsoDateTimeConverter { DateTimeFormat = "d/MM/yyyy" });
        }
    }
}
