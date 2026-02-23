using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Tracker.Models
{
    public class AttendanceSession
    {
        public List<string> ConfirmedAttendeesDiscordUserIds { get; set; }
        public DateTime Date { get; set; }
        public string KeeperDiscordUserID { get; set; }
    }
}
