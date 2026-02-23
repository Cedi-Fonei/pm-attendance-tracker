using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Tracker.Services
{
    public class SpreadsheetService
    {
        // TBD: Parses the current AttendanceHistorySheet from the keeper running this bot on their local device. If none exists yet, the sheet is initialized.
        // This is an automatic process as the keeper begins to run the bot.
        public Task FetchOrCreateCurrentSheet()
        {
            throw new NotImplementedException();
        }

        // TBD: An Admin downloads the current AttendanceHistorySheet as a spreadsheet file. The bot will post the file as an attachment to download.
        public Task DownloadSheet()
        {
            throw new NotImplementedException();
        }

        // TBD: Saves today's updated AttendanceHistorySheet, applying all updates due to added/removed member rows and the added AttendanceSession column, as well as aggregate data such as recent attendance totals and standing.
        // This process runs as the admin ends taking attendance for the session.
        public Task SaveAttendanceSession()
        {
            throw new NotImplementedException();
        }
    }
}
