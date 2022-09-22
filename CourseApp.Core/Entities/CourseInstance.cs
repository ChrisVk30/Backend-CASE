using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEnv.Core.Entities
{
    public class CourseInstance
    {
        public int CourseInstanceId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public Course Course { get; set; }
    }
}
