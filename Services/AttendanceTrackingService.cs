using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Tracker.Services
{
    public class AttendanceTrackingService
    {
        // TBD: An admin initializes a new AttendanceSession in the AttendanceHistorySheet.
        public Task BeginNewSession()
        {
            throw new NotImplementedException();
        }

        // TBD: An admin finalizes a new AttendanceSession in the AttendanceHistorySheet.
        public Task EndNewSession()
        {
            throw new NotImplementedException();
        }

        // TBD: Checks whether a user is in the currently tracked AttendanceSession (if there is one), and add them to it or update their display name IF necessary.
        // It is important this process is asynchronous and can be performed with many different users simultaneously.
        // This is an automatic process that should not run manually.
        public Task CheckUserAttendance()
        {
            throw new NotImplementedException();
        }

        // TBD: An admin queries the entire list of members in good standing.
        public Task QueryAllUsersInGoodStanding()
        {
            throw new NotImplementedException();
        }

        // TBD: A single user queries whether or not they are in good standing.
        public Task QuerySingleUserInGoodStanding()
        {
            throw new NotImplementedException();
        }

        // TBD: Removes a user from the AttendanceHistorySheet.
        // This should run automatically IF and ONLY IF a user is banned from the server due to being identified as a bad actor. This should not run manually.
        // If, for any reason, one must manually remove a user from the records, you can do so by manually editting the spreadsheet file to remove their row from it.
        public Task RemoveUserFromRecords()
        {
            throw new NotImplementedException();
        }
    }
}
