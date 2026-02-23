using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Tracker.Models
{
    public class AttendanceHistorySheet
    {
        public List<AttendanceSession> PastSessions { get; set; }
        public AttendanceSession CurrentSession { get; set; }
        public List<MemberHistoryRow> TrackedMembers { get; set; }
    }
}
