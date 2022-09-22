using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CourseEnv.Core.Services;

namespace CourseEnv.Core.Entities
{
    public class CourseOverview
    {
        //[JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public string CourseCode { get; set; }
    }
}
