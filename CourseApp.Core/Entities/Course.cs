using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Core.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public string CourseCode { get; set; }
        public List<CourseInstance>? CourseInstances { get; set; }
    }
}
