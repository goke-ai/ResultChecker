using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultCheckerBwaApp.Shared.Models
{
    public class SearchStudentResultModel
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public int SemesterId { get; set; }
        public string SemesterName { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public int StudentId { get; set; }
        public string StudentMatricNo { get; set; }
    }
}
